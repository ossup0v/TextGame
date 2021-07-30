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
        private double _fireBallBaseDamage = 10;
        private double _fireBallBaseMPCost = 5;
        public FireBallSpell(Character owner) : base(owner) { }

        public override bool TryUseAttack(Character target)
        {
            if (Constants.OnDebugLog)
            {
                ConsoleManager.ShowMessageAndReturnCurPos($"{nameof(FireBallSpell)} was casted!", new Point(0, 20));
            }

            var damage = GetDamageExcludingTargetStats();

            if (CheckForEnoughMPForSpell())
            {
                _owner.DecreaceStat(StatKind.MP, GetMPCost());
                target.FillDamage(damage);
                return true;
            }
            return false;
        }

        protected override double GetMPCost()
        {
            return _fireBallBaseMPCost;
        }

        protected override double GetDamageExcludingTargetStats()
        {
            return _fireBallBaseDamage * _owner.GetStat(StatKind.MagicAttackPower);
        }
    }
}
