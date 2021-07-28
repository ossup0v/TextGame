using System;

namespace TextGame.UI
{
    public static class ConsoleManager
    {
        public static void ShowMap(char[][] map)
        {
            for (int X = 0; X < map.Length; X++)
            {
                for (int Y = 0; Y < map[X].Length; Y++)
                {
                    Console.Write(map[X][Y]);
                }
                Console.WriteLine();
            }
        }
    }
}