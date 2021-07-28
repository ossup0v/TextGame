using System;
using System.Collections;
using System.Collections.Generic;
using TextGame.Characters;
using TextGame.Map;

namespace TextGame.UI
{

#warning need to refactor ConsoleManager
    public static class ConsoleManager
    {
        public static void ShowMap(char[][] map, IEnumerable<Character> enemies, Character player)
        {
            Console.SetCursorPosition(0, 0);
            for (int X = 0; X < map.Length; X++)
            {
                for (int Y = 0; Y < map[X].Length; Y++)
                {
                    Console.Write(map[X][Y]);
                }
                Console.WriteLine();
            }

            //����� �������� ������ �����
            foreach (var enemy in enemies)
                ShowSymbol(enemy.SymbolOnMap, enemy.Position);

            //����� �������� ������ ����� � ������
            ShowSymbol(player.SymbolOnMap, player.Position);
        }

        public static void LogError(string message)
        {
            var currentCursorPosition = Console.GetCursorPosition();
            var currentBGColor = Console.BackgroundColor;
            Console.SetCursorPosition(0,0);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR! {message}");
            Console.BackgroundColor = currentBGColor;
            Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
        }

        public static void ShowSymbol(char symbol, Point point)
        {
            ReturnCursourPositionInOldValue(() =>
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(symbol);
            });
        }

        public static void ShowMessageOnFullMonitor(string message)
        {
            ReturnCursourPositionInOldValue(() =>
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }

                ShowMessageOnCenter(message);
            });
        }

        public static void ShowMessageOnCenter(string message)
        {
            ReturnCursourPositionInOldValue(() =>
            {
                var centerOfMonitor = new Point((Math.Max(0,Console.WindowWidth - message.Length ) )/ 2, Console.WindowHeight / 2);
                Console.SetCursorPosition(centerOfMonitor.X, centerOfMonitor.Y);
                Console.WriteLine(message);
            });
        }

        public static void ReturnCursourPositionInOldValue(Action action)
        {
            var oldPosition = Console.GetCursorPosition();
            action();
            Console.SetCursorPosition(oldPosition.Left, oldPosition.Top);
        }

        public static void ShowMessageAndReturnCurPos(string message, Point position)
        {
            ReturnCursourPositionInOldValue(() =>
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write(message);
            });
        }

        public static void ShowMessageAndReturnCurPos(Point position, params string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                ReturnCursourPositionInOldValue(() =>
                {
                    Console.SetCursorPosition(position.X, position.Y + i);
                    Console.Write(messages[i]);
                });
            }
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}