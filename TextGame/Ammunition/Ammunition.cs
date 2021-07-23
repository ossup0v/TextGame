using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Ammunition
{
	public abstract class Ammunition
	{
		public Dictionary<StatKind, double> Stats { get; set; }
		public AmmunitionSlot Slot { get; set; }
	}
}
