using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Ammunition;
using TextGame.Attacks;
using TextGame.Common;
using TextGame.Inventory;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters
{
    public enum CharacterState
    { 
        Unexpected,
        Walk,
        InBattle,
        InInventory,
        InMenu
    }
	
    
    public abstract class Character : IHaveStats, IHavePosition
	{
        public CharacterState State { get; private set; } = CharacterState.Unexpected;
        public Dictionary<StatKind, double> BaseStats { get; private set; } = new Dictionary<StatKind, double>();
		public char SymbolOnMap { get; protected set; }
        public List<AttackBase> AvailableAttacks { get; private set; } = new List<AttackBase>();
        public readonly CharacterInventoryContainer Inventory = new CharacterInventoryContainer();

        public Point Position { get; set; }

        public abstract void FillDamage(double damage);

        public abstract void UseAttackToTarget(Character target);

		public Point GetPosition() => Position;

        public double GetStat(StatKind statKind)
        {
			var result = 0D;

			BaseStats.TryGetValue(statKind, out var baseStatValue);
			result += baseStatValue;

            foreach (var item in Inventory.DressedAmmunition.Values)
				result += item.GetStat(statKind);

			return result;
        }

        public Character AddAttacks(params AttackBase[] attacks)
        {
            foreach (var attak in attacks)
                AvailableAttacks.Add(attak);

            return this;
        }

        public Character SetBaseStat(params (StatKind, double)[] statsAndValue)
        {
            foreach (var statAndValue in statsAndValue)
                BaseStats.Add(statAndValue.Item1, statAndValue.Item2);

            return this;
        }

        public Character SetBaseAmmunition(params AmmunitionBase[] ammunitions)
        {
            foreach (var ammunition in ammunitions)
                Inventory.DonAmmunitionOnSlot(ammunition);

            return this;
        }

        public void DecreaceStat(StatKind stat, double value)
            => ChangeBaseStat(stat, value, ActionKind.Decreace);

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

        public void ChangeState(CharacterState newState)
        {
            State = newState;
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

        public abstract ConsoleKey GetKey();
    }
}
