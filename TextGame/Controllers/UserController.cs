using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Attacks;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Controllers
{
    public class UserController : IPlayerController
    {
        public AttackBase GetWontAttack(List<AttackBase> availableAttacks)
        {
            while (true)
            {
                var descriptionOfAttacks = new StringBuilder();

                for (int i = 0; i < availableAttacks.Count; i++)
                    descriptionOfAttacks.Append($"{i + 1}: {availableAttacks[i].GetDescription()} {Environment.NewLine}");

                ConsoleManager.ShowMessageAndReturnCurPos(descriptionOfAttacks.ToString(), new Point(0, 16));
                var choose = ConsoleManager.GetNumKey();

                if (!choose.HasValue)
                {
                    ConsoleManager.ShowMessageAndReturnCurPos($"Вы выбрали недопустимую атаку!                             ", new Point(0, 15));
                    continue;
                }

                if (choose - 1 < availableAttacks.Count && choose > 0)
                {
                    return availableAttacks[choose.Value - 1];
                }
            }
        }

        public Point GetWontPosition(Point currentPosition)
        {
            var key = ConsoleManager.GetKey();

            switch (key)
            {
                default: return currentPosition;
            }
        }
    }
}
