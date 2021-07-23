using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Attacks;

namespace TextGame.Characters
{
	public abstract class Character
	{
		public double Health { get; set; }
		public double Defence { get; set; }
		public double Armor { get; set; }
		public List<AttackBase> AvailableAttacks { get; set; }

		public abstract void FillDamage(double damage);
	}
}
