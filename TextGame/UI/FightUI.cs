using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;
using TextGame.Map;

namespace TextGame.UI
{
    public class FightUI
    {
        public void ShowStats(Character player, Character enemy)
        {
            ConsoleManager.ClearConsole();
            ConsoleManager.ShowMessageAndReturnCurPos(
                new Point(0, 0)
                , "Player:"
                , $"Health: {player.GetStat(StatKind.Health)}"
                , $"Attack: {player.GetStat(StatKind.Attack)}"
                , $"AttackPower: {player.GetStat(StatKind.AttackPower)}"
                );

            ConsoleManager.ShowMessageAndReturnCurPos(
                new Point(50, 0)
                , "Enemy:"
                , $"Health: {enemy.GetStat(StatKind.Health)}"
                , $"Attack: {enemy.GetStat(StatKind.Attack)}"
                , $"AttackPower: {enemy.GetStat(StatKind.AttackPower)}"
                );
        }
    }
}
