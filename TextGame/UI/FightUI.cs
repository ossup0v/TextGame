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

            ShowStats(player, new Point(0, 0));

            ShowStats(enemy, new Point(50, 0));
        }

        private void ShowStats(Character character, Point at)
        {
            ConsoleManager.ShowMessageAndReturnCurPos(
                at
                , "Player:"
                , $"Health: {character.GetStat(StatKind.Health)}"
                , $"MP: {character.GetStat(StatKind.MP)}"
                , $"Defence: {character.GetStat(StatKind.Defence)}"
                , $"Armor: {character.GetStat(StatKind.Armor)}"
                , $"Attack: {character.GetStat(StatKind.Attack)}"
                , $"AttackPower: {character.GetStat(StatKind.AttackPower)}"
            );
    
        }
    }
}
