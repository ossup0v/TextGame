using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Attacks;
using TextGame.Attacks.Spells;
using TextGame.Common;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters
{
	public class Player : Character
	{
		private ILogger _logger;
		private Player(ILogger logger)
		{
			_logger = logger;
			SymbolOnMap = 'P';
		}

        public override void FillDamage(double damage)
		{
			if (damage < 0)
			{
				_logger.Log($"{nameof(Player)} getting damage less then zero! {nameof(damage)}: {damage}");
			}

			var defence = GetStat(StatKind.Defence);
			var armor = GetStat(StatKind.Armor);
			var finalDamage = damage * ((100 - defence) / 100) - armor; 
			
			ChangeBaseStat(StatKind.Health, finalDamage, ActionKind.Decreace);
		}

		public override double GetFinalHitDamage()
		{
			var attack = GetStat(StatKind.Attack);
			var attackPower = GetStat(StatKind.AttackPower);

			return attack * attackPower;
		}

		public override Point GetWontPointToMove()
		{
			var key = Console.ReadKey().Key;

			switch (key)
			{
				case ConsoleKey.W: return Position.MoveTop();
				case ConsoleKey.S: return Position.MoveDown();
				case ConsoleKey.A: return Position.MoveLeft();
				case ConsoleKey.D: return Position.MoveRight();
				default:		   return Position;
			}
		}

		//public override double GetPhysicalAttackDamageFinal()
		//{
		//	var attack = GetStat(StatKind.Attack);
		//	var attackPower = GetStat(StatKind.AttackPower);
		//
		//	return attack * attackPower;
		//}

		public static Player CreatePlayer(
			double health = 100
			, double attack = 2
			, double attackPower = 2
			, double defence = 10)
		{
			return new Player(new DummyLogger())
			{
				AvailableAttacks = new List<AttackBase> { new FireBallSpell() },
				BaseStats = new Dictionary<StatKind, double>
				{
					[StatKind.Health] = health,
					[StatKind.Attack] = attack,
					[StatKind.AttackPower] = attackPower,
					[StatKind.Defence] = defence
				}
			};
		}
	}
}
