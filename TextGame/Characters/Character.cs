using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Ammunition;
using TextGame.Attacks;
using TextGame.Common;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters
{
	public abstract class Character : IHaveStats, IHavePosition
	{
        public Dictionary<StatKind, double> BaseStats { get; set; } = new Dictionary<StatKind, double>();
		public char SymbolOnMap { get; protected set; }
        public List<AttackBase> AvailableAttacks { get; set; } = new List<AttackBase>();
        public Dictionary<AmmunitionSlotKind, AmmunitionBase> PutOnAmmunition { get; set; } = new Dictionary<AmmunitionSlotKind, AmmunitionBase>(); 

		public Point Position { get; set; }

        public abstract void FillDamage(double damage);

        public abstract double GetFinalHitDamage(Character target);

		public Point GetPosition() => Position;

        public double GetStat(StatKind statKind)
        {
			var result = 0D;

			BaseStats.TryGetValue(statKind, out var baseStatValue);
			result += baseStatValue;

            foreach (var item in PutOnAmmunition.Values)
				result += item.GetStat(statKind);

			return result;
        }

        protected void ChangeBaseStat(StatKind stat, double value, ActionKind actionKind)
        {
            if (BaseStats.ContainsKey(stat))
                switch (actionKind)
                {
                    case ActionKind.Increace:
                        BaseStats[stat] += value;
                        break;
                    case ActionKind.Decreace:
                        BaseStats[stat] -= value;
                        break;
                    case ActionKind.Multiply:
                        BaseStats[stat] *= value;
                        break;
                    default:
                        break;
                }
            else
                ConsoleManager.LogError($"{nameof(ChangeBaseStat)}: have no base stat {stat}, all base stats is {string.Join(" ", BaseStats.Keys)}");
        }

		protected enum ActionKind
		{ 
			Increace,
			Decreace,
            Multiply
        }

        public abstract Point GetWontPointToMove();

        public void ApplyNewPosition(Point point)
        {
            Position = point.Copy();
        }

        public bool IsAlive => BaseStats[StatKind.Health] > 0;
    }
}
