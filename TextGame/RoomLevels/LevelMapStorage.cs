﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.RoomLevels
{
    public static class LevelMapStorage
    {
        public static Dictionary<int, char[][]> Levels = new Dictionary<int, char[][]>
        {
            [1] = new char[][]
            {
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                new char[] {'#', 'P', 'H', 'L', 'S', ' ', ' ', 'E', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', '#' },
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            },
            [2] = new char[][]
            {
                 new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                 new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'E', ' ', ' ', '*', '#' },
                 new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#' },
                 new char[] {'#', ' ', 'P', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                 new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                 new char[] {'#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                 new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                 new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            },
            [3] = new char[][]
            {
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                new char[] {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', ' ', 'E', ' ', ' ', '#', '#', '#', '#', '#', '#' },
                new char[] {'#', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', ' ', '#', 'P', '#', ' ', '#', '#', '#', ' ', ' ', '#' },
                new char[] {'#', ' ', '#', ' ', '#', ' ', 'E', 'H', '#', ' ', ' ', '#' },
                new char[] {'#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', ' ', '#' },
                new char[] {'#', '*', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            },
        };
    }
}
