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
        public abstract double GetTotalDamage(Character attacker, Character target);
    }
}
