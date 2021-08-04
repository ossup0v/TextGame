using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Common;
using TextGame.Inventory;

namespace TextGame.Ammunition
{
	public abstract class AmmunitionBase : InventoryItemBase, IHaveStats
    {
        public AmmunitionBase(AmmunitionSlotKind slot, char symbol) : base(symbol)
        {
            Slot = slot;
        }

        public Dictionary<StatKind, double> Stats { get; set; } = new Dictionary<StatKind, double>();
		public AmmunitionSlotKind Slot { get; set; }

        public double GetStat(StatKind statKind)
        {
            Stats.TryGetValue(statKind, out var statValue);
            return statValue;
        }
    }
}
