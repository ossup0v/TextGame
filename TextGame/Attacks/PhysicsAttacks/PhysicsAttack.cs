using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Characters;

namespace TextGame.Attacks
{
	public class PhysicsAttack : AttackBase
	{
		public override double GetTotalDamage(Character target)
		{
			return 1;
		}
	}
}
