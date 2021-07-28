using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;
using TextGame.Common;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Attacks.Spells
{
    public class FireBallSpell : MagicAttack
    {
        public override string GetDescription()
        {
            return $"{nameof(FireBallSpell)} необходимо 5 маны, нанесет 20 урона";
        }

        public override double GetTotalDamage(Character attacker, Character target)
        {
            if (Constants.OnDebugLog)
            {
                ConsoleManager.ShowMessageAndReturnCurPos($"{nameof(FireBallSpell)} was casted!", new Point(0,20));
            }

            return 20;
        }
    }
}
