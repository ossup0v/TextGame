using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Inventory;
using TextGame.Map;

namespace TextGame.UI
{
    public class InventoryUI
    {
        private char[][] _map;
        private Dictionary<Point, InventoryItemBase> _itemCoordMap;
        private Point _playerCoursorPosition;

        public void ShowInventory(CharacterInventoryContainer inventory)
        {
            ConsoleManager.ClearConsole();
            Console.CursorVisible = true;

            var maxCount = Math.Max(inventory.Inventory.Count, inventory.DressedAmmunition.Count) + 2;

            _itemCoordMap = new Dictionary<Point, InventoryItemBase>();
            _map = new char[5][];
            _playerCoursorPosition = new Point(1, 1);

            for (int y = 0; y < _map.Length; y++)
                _map[y] = new char[maxCount];

            for (int x = 0; x < _map[0].Length; x++)
            {
                _map[0][x] = '#';
                _map[2][x] = '#';
                _map[4][x] = '#';
            }

            _map[1][0] = '#';
            _map[3][0] = '#';
            _map[1][maxCount - 1] = '#';
            _map[3][maxCount - 1] = '#';

            var counter = 1;
            foreach (var ammunition in inventory.DressedAmmunition.Values)
            {
                _itemCoordMap.Add(new Point(counter, 1), ammunition);
                _map[1][counter] = ammunition.Symbol;
                counter++;
            }

            counter = 1;
            foreach (var item in inventory.Inventory)
            {
                _itemCoordMap.Add(new Point(counter, 3), item);
                _map[3][counter] = item.Symbol;
                counter++;
            }

            foreach (var (key, value) in _itemCoordMap)
            {
                _map[key.Y][key.X] = value.Symbol;
            }

            Do();
            ConsoleManager.ClearConsole();
            Console.CursorVisible = false;
        }

        private void Do()
        {
            while (true)
            {
                ShowAndDescriptionInventory();
                var key = ConsoleManager.GetKey();
                if (key == ConsoleKey.A
                    || key == ConsoleKey.W
                    || key == ConsoleKey.S
                    || key == ConsoleKey.D)
                {
                    Console.SetCursorPosition(_playerCoursorPosition.X, _playerCoursorPosition.Y);
                    _playerCoursorPosition = _playerCoursorPosition.MoveTo(key);
                }
                else
                    return;
            }
        }

        private void ShowAndDescriptionInventory()
        {
            ConsoleManager.ShowMap(_map, null, null);
            ConsoleManager.ShowMessageAndReturnCurPos($"X:{_playerCoursorPosition.X} Y:{_playerCoursorPosition.Y}    ", new Point(0,10));
            
            if(_itemCoordMap.ContainsKey(_playerCoursorPosition))
                ConsoleManager.ShowMessageAndReturnCurPos(_itemCoordMap[_playerCoursorPosition].GetDescription() + "                                             ",
                    new Point(0, 5));
        }
    }
}