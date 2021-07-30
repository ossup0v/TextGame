using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;
using TextGame.RoomLevels;
using TextGame.UI;

namespace TextGame.Controllers
{
    public class GameController
    {
        public GameController(Player player)
        {
            _player = player;
            _levels = RoomLevel.CreateLevels(_player);
        }

        private Player _player;
        private List<RoomLevel> _levels;

        public void StartGame()
        {
            foreach (var level in _levels)
            {
                level.StartGameLoop();
                ConsoleManager.ClearConsole();
            }
            ConsoleManager.ShowMessageOnFullMonitor("УРА! ИГРА ПРОЙДЕНА!");
        }
    }
}
