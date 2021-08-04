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
            var exodus = ExodusOfLevel.LOL;
            foreach (var level in _levels)
            {
                exodus = level.StartLevelLoop();
                ConsoleManager.ClearConsole();

                if(exodus == ExodusOfLevel.Loose)
                    break;
            }

            switch (exodus)
            {
                case  ExodusOfLevel.Loose:
                    ConsoleManager.ShowMessageOnFullMonitor("Вы проиграли...");
                    break;
                case  ExodusOfLevel.LOL:
                    ConsoleManager.ShowMessageOnFullMonitor("УРА! ИГРА ПРОЙДЕНА! LOL");
                    break;
                case  ExodusOfLevel.Victory:
                    ConsoleManager.ShowMessageOnFullMonitor("УРА! ИГРА ПРОЙДЕНА!");
                    break;
            }
        }
    }
}
