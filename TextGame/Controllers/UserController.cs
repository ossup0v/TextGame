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
        [CanBeNull]
        public AttackBase GetWontAttack(List<AttackBase> availableAttacks)
        {
            while (true)
            {
                ConsoleManager.ShowMessageAndReturnCurPos("Выберите атаку - для пропуска нажмите 0", new Point(0, 15));
                var descriptionOfAttacks = new StringBuilder();
                for (int i = 0; i < availableAttacks.Count; i++)
                    descriptionOfAttacks.Append($"{i + 1}: {availableAttacks[i].GetDescription()}");

                ConsoleManager.ShowMessageAndReturnCurPos(descriptionOfAttacks.ToString(), new Point(0, 16));
                var choose = Console.ReadKey().KeyChar;
                if (int.TryParse(choose.ToString(), out var chooseNum))
                {
                    if (chooseNum == 0)
                    {
                        return null;
                    }

                    if (chooseNum - 1 < availableAttacks.Count)
                    {
                        return availableAttacks[chooseNum - 1];
                    }
                }

                ConsoleManager.ShowMessageAndReturnCurPos($"Вы выбрали недопустимую атаку! вы ввели {choose}", new Point(0, 14));
            }
        }

        public Point GetWontPosition(Point currentPosition)
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.W: return currentPosition.MoveTop();
                case ConsoleKey.S: return currentPosition.MoveDown();
                case ConsoleKey.A: return currentPosition.MoveLeft();
                case ConsoleKey.D: return currentPosition.MoveRight();
                default: return currentPosition;
            }
        }
    }
}
