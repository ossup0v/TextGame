using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.Attacks
{
	public abstract class MagicAttack : AttackBase
    {
        public MagicAttack(Character owner) : base(owner) { }

        protected override string GetDescriptionInternal()
        {
            return $"{this.GetType().Name} нанесёт урона {GetDamageExcludingTargetStats()}, требуется маны {GetMPCost()}";
        }

        protected abstract double GetMPCost();

        protected bool SpendMPToUseSpell()
        {
            var ownerMP = _owner.GetStat(StatKind.MP);
            if (ownerMP >= GetMPCost())
            {
                _owner.DecreaceStat(StatKind.MP, GetMPCost());
                return true;
            }

            return false;
        }
        protected bool CheckForEnoughMPForSpell()
        {
            var ownerMP = _owner.GetStat(StatKind.MP);
            return ownerMP >= GetMPCost();
        }
    }
}
