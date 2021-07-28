using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Ammunition;
using TextGame.Attacks;
using TextGame.Common;
using TextGame.Map;

namespace TextGame.Characters
{
	public abstract class Character : IHaveStats, IHavePosition
	{
		public Dictionary<StatKind, double> BaseStats { get; set; }
		public abstract char SymbolOnMap { get; protected set; }
		public double Health { get; set; }
		public double Defence { get; set; }
		public double Armor { get; set; }
		public List<AttackBase> AvailableAttacks { get; set; }
        public Dictionary<AmmunitionSlotKind, AmmunitionBase> PutOnAmmunition { get; set; }

		public Point Position { get; set; }

        public abstract void FillDamage(double damage);

		public Point GetPosition() => Position;

        public double GetStat(StatKind statKind)
        {
			var result = 0D;
			BaseStats.TryGetValue(statKind, out var baseStatValue);
			result += baseStatValue;

            foreach (var item in PutOnAmmunition.Values)
            {
				item.Stats.TryGetValue(statKind, out var itemStatValue);
				result += itemStatValue;
            }

			return result;
        }
    }
}
