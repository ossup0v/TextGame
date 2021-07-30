using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.Attacks
{
    public abstract class AttackBase
    {
        protected readonly Character _owner;
        public AttackBase(Character owner) { _owner = owner; }
        public abstract bool TryUseAttack(Character target);
        protected abstract double GetDamageExcludingTargetStats();

        protected virtual string GetDescriptionInternal()
        {
            return $"У атаки {this.GetType().Name} нет описания!";
        }

        public string GetDescription()
        {
            return GetDescriptionInternal();
        }
    }
}
