using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.Attacks.PhysicsAttacks
{
    public class DefaultPhysicAttack : PhysicsAttackBase
    {
        private int _physicAttackBaseDamage = 5;
        public DefaultPhysicAttack(Character owner) : base(owner) { }

        public override bool TryUseAttack(Character target)
        {
            var damage = GetDamageExcludingTargetStats() * ((100 - target.GetStat(StatKind.Defence)) / 100);
            target.FillDamage(damage);
            return true;
        }

        protected override double GetDamageExcludingTargetStats() =>
            _physicAttackBaseDamage * _owner.GetStat(StatKind.PhysicsAttackPower);

    }
}
