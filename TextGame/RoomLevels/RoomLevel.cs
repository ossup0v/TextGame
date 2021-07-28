using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.RoomLevels
{
    public class RoomLevel
    {

        private RoomLevel(int level, char[][] map, List<Character> enemies)
        {
            Level = level;
            _map = map;
            _enemies = enemies;
        }
        public int Level { get; }
        private List<Character> _enemies = new List<Character>();
        private char[][] _map;

        public static List<RoomLevel> CreateLevels()
        {
            return new List<RoomLevel>
            {
                new RoomLevel(1,
                    map: new char[][]
                    {
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                    }, new List<Character>()),
                new RoomLevel(2,
                    map: new char[][]
                    {
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                         new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                    }, new List<Character>())

            };
        }
    }
}
