using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;
using TextGame.Common;
using TextGame.UI;

namespace TextGame.FightSystem
{
    public class FightManager
    {
        private FightUI _fightUI;
        public FightManager(FightUI fightUI)
        {
            _fightUI = fightUI;
        }

        public void Fight(Character attacker, Character defender)
        {
            string logMessage = string.Empty;

            while (true)
            {
                _fightUI.ShowStats(attacker, defender);
                if (Constants.OnDebugLog)
                    logMessage += $"attacker health {attacker.GetStat(StatKind.Health)}, defender health {defender.GetStat(StatKind.Health)} {Environment.NewLine}";

                //атакующий бьет защищающегося
                defender.FillDamage(attacker.GetFinalHitDamage(defender));
                if (!defender.IsAlive)
                    break; //TODO
                //защищающийся бьет атакующего
                attacker.FillDamage(defender.GetFinalHitDamage(attacker));
                if (!attacker.IsAlive)
                    break; //TODO
            }

            if (Constants.OnDebugLog)
                ConsoleManager.ShowMessageOnCenter(logMessage);

            ConsoleManager.ClearConsole();
        }
    }
}
