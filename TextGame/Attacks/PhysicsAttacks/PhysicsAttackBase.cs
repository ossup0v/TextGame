using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.Attacks
{
	public  abstract class PhysicsAttackBase : AttackBase
    {
        public PhysicsAttackBase(Character owner) : base(owner) { }
        protected override string GetDescriptionInternal()
        {
            return $"{this.GetType().Name} нанесёт урона {GetDamageExcludingTargetStats()}";
        }
    }
}
