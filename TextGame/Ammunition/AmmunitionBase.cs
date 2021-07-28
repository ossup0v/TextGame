using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Ammunition
{
	public abstract class AmmunitionBase
	{
        public AmmunitionBase(AmmunitionSlotKind slot)
        {
            Slot = slot;
        }

		public Dictionary<StatKind, double> Stats { get; set; }
		public AmmunitionSlotKind Slot { get; set; }
	}
}
