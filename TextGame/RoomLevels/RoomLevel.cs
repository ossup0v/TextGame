using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;
using TextGame.Characters.Enemies;
using TextGame.FightSystem;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.RoomLevels
{
    public class RoomLevel
    {
        private RoomLevel(
            int level
            , char[][] map
            , List<Character> enemies
            , Character player
            , Point playerStartPosition
            , FightManager fightManager)
        {
            Level = level;
            _player = player;
            _playerStartPosition = playerStartPosition;
            _enemies = enemies.ToDictionary(key => key.Position, value => value);
            _fightManager = fightManager;
            _map = map;
        }

        public int Level { get; }
        private Character _player { get; }
        private Point _playerStartPosition { get; }

        private FightManager _fightManager { get; }

        private Dictionary<Point, Character> _enemies;
        private char[][] _map;

        public static List<RoomLevel> CreateLevels(Character player)
        {
            return new List<RoomLevel>
            {
                new RoomLevel(1,
                    map: new char[][]
                    {
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                    }, new List<Character>(), player, new Point(1, 1), new FightManager(new FightUI())),
                new RoomLevel(2,
                    map: new char[][]
                    {
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                    }, 
                    new List<Character> 
                    { 
                        DummyEnemy.CreateEnemy('E', new Point(15, 1)) 
                    }, 
                    player, new Point(1, 1), new FightManager(new FightUI()))
            };
        }

        public void StartGameLoop()
        {
            InitLevel();

            while (true)
            {
                ConsoleManager.ShowMap(_map, _enemies.Values, _player);
                var wontPosition = _player.GetWontPointToMove();

                if (CheckPositionForAvailable(wontPosition))
                    _player.ApplyNewPosition(wontPosition);
                
                var enemyPosition = TryGetEnemyAroundPlayer(wontPosition);
                
                if (enemyPosition != null)
                    Fight(enemyPosition);

                if (CheckForEndOfLevel(_player.Position))
                    return;
            }
        }

        private void InitLevel()
        {
            _player.ApplyNewPosition(_playerStartPosition);

            foreach (var enemy in _enemies)
                _map[enemy.Key.Y][ enemy.Key.X] = enemy.Value.SymbolOnMap;
        }

        #region Fight

        private Point TryGetEnemyAroundPlayer(Point wontPosition)
        {
            return IsSymbolInArea(4, 'E', wontPosition);
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

        private bool CheckPositionForAvailable(Point wontPosition)
        {
            var symbol = _map[wontPosition.Y][wontPosition.X];

            switch (symbol)
            {
                case '#': return false;
                default: return true;
            }
        }

        private bool CheckForEndOfLevel(Point position)
        {
            var symbol = _map[position.Y][position.X];

            switch (symbol)
            {
                case '*': return true;
                default: return false;
            }
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
