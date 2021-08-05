using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using TextGame.Ammunition;
using TextGame.Characters;
using TextGame.Characters.Enemies;
using TextGame.Common;
using TextGame.FightSystem;
using TextGame.Inventory;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.RoomLevels
{
    public class RoomLevel
    {
        private RoomLevel(
            int level
            , char[][] map
            , Character player
            , FightManager fightManager
            , InventoryUI inventoryUi)
        {
            _level = level;
            _player = player;
            _fightManager = fightManager;
            _map = map;
            _inventoryUi = inventoryUi;
        }

        private readonly int _level;
        private readonly Character _player;
        private readonly FightManager _fightManager;
        private readonly Dictionary<Point, Character> _enemies = new Dictionary<Point, Character>();
        private readonly char[][] _map;
        private readonly InventoryUI _inventoryUi;
        private readonly Dictionary<Point, InventoryItemBase> _drop = new Dictionary<Point, InventoryItemBase>();
        private readonly Random _r = new Random();

        public static List<RoomLevel> CreateLevels(Character player)
        {
            var levels = new List<RoomLevel>();
            var fightManager = new FightManager(new FightUI());
            var inventoryUi = new InventoryUI();

            foreach (var level in LevelMapStorage.Levels)
                levels.Add(new RoomLevel(level.Key, level.Value, player, fightManager, inventoryUi));

            return levels;
        }

        public ExodusOfLevel StartLevelLoop()
        {
            InitLevel();

            while (true)
            {
                ConsoleManager.ShowMap(_map, _enemies.Values, _player);
                StartGameStep();


                if (CheckForWinLevel(_player.Position))
                    return ExodusOfLevel.Victory;
                if(!_player.IsAlive)
                    return ExodusOfLevel.Loose;
            }
        }

        private void StartGameStep()
        {
            var playerChar = _player.GetKey();

            switch (playerChar)
            {
                case ConsoleKey.E:
                    _inventoryUi.ShowInventory(_player.Inventory);
                    break;
                case ConsoleKey.Escape:
                    //TODO Menu
                    break;
                case ConsoleKey.W: 
                case ConsoleKey.S: 
                case ConsoleKey.A:
                case ConsoleKey.D:
                    switch (_player.State)
                    {
                        case CharacterState.Walk:
                            MovePlayer(playerChar);
                            break;
                        case CharacterState.Unexpected:
                        case CharacterState.InBattle:
                        case CharacterState.InInventory:
                        case CharacterState.InMenu:
                        default:
                            ConsoleManager.LogError($"_player.State {_player.State}");
                            break;
                    }
                    break;
                default:
                    ConsoleManager.LogError($"playerChar {playerChar}");
                    break;
            }
        }

        private void MovePlayer(ConsoleKey consoleKey)
        {
            var currentPosition = _player.Position;
            var wontPosition = currentPosition.MoveTo(consoleKey);

            if (CheckPositionForAvailable(wontPosition))
                _player.ApplyNewPosition(wontPosition);

            var enemyPosition = TryGetEnemyAroundPlayer(wontPosition);

            if (enemyPosition != null)
                Fight(enemyPosition);

            TryGetDrop(wontPosition);
        }

        private void InitLevel()
        {
            for (int Y = 0; Y < _map.Length; Y++)
            {
                for (int X = 0; X < _map[Y].Length; X++)
                {
                    if(_map[Y][X] == ' ')
                        continue;

                    if (Constants.DummyEnemyChar == _map[Y][X])
                    {
                        _enemies.Add(new Point(X, Y), 
                            DummyEnemy.CreateEnemy(
                                Constants.DummyEnemyChar
                                , new Point(X, Y)
                                , _r.Next(Constants.MinEnemyHealth, Constants.MaxEnemyHealth)));
                    }
                    else if (Constants.PlayerChar == _map[Y][X])
                    {
                        _player.ApplyNewPosition(new Point(X, Y));
                        _map[Y][X] = ' ';
                    }
                    else if (SymbolItemMap.Instance.AllItemSymbols.Contains(_map[Y][X]))
                    {
                        _drop.Add(new Point(X, Y), SymbolItemMap.Instance.GetItem(_map[Y][X]));
                    }
                }
            }
        }

        private void TryGetDrop(Point from)
        {
            if (_drop.ContainsKey(from))
            {
                var drop = _drop[from];
                
                if(drop is AmmunitionBase ammunition)
                    _player.Inventory.DonAmmunitionOnSlot(ammunition);
                else
                    _player.Inventory.AddToInventory(drop);

                _drop.Remove(from);
                _map[from.Y][from.X] = ' ';
            }
        }

        #region Fight

        private Point TryGetEnemyAroundPlayer(Point wontPosition)
        {
            return IsSymbolInArea(2, Constants.DummyEnemyChar, wontPosition);
        }

        private void Fight(Point at)
        {
            _fightManager.Fight(_player, _enemies[at]);
            
            if (!_enemies[at].IsAlive)
            {
                _map[at.Y][at.X] = ' ';
                _enemies.Remove(at);
            }
        }

        #endregion

        private bool CheckPositionForSymbol(char targetSymbol, Point position)
        {
            return _map[position.Y][position.X] == targetSymbol;
        }

        private bool CheckPositionForAvailable(Point wontPosition)
        {
            return !CheckPositionForSymbol('#', wontPosition);
        }

        private bool CheckForWinLevel(Point position)
        {
            return CheckPositionForSymbol('*', position);
        }
        
        [CanBeNull]
        private Point IsSymbolInArea(int area, char target, Point position)
        {
            var maxX = Math.Min(position.X + area / 2, _map[0].Length - 1);//костыль, считаем что карта квадратная, хотя это можно быть не так
            var maxY = Math.Min(position.Y + area / 2, _map.Length - 1);


            for (var x = Math.Max(position.X, 0); x <= maxX; x++)
                for (var y = Math.Max(position.Y, 0); y <= maxY; y++)
                {
                    var symbol = _map[y][x];
                    if (symbol == target)
                        return new Point(x, y);
                }

            return null;
        }
    }
}
