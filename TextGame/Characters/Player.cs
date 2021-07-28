using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Attacks;
using TextGame.Attacks.Spells;
using TextGame.Common;
using TextGame.Controllers;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters
{
	public class Player : Character
	{
		private ILogger _logger;
        private readonly IPlayerController _playerController;

        private Player(ILogger logger, IPlayerController playerController)
		{
			_logger = logger;
            _playerController = playerController;
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

		public override double GetFinalHitDamage(Character tarter)
        {
            var wontAttack = _playerController.GetWontAttack(AvailableAttacks);

            if (wontAttack == null) // у игрока или нет особых атак или он не хочет их использовать
				return GetBaseHitDamage();

			return wontAttack.GetTotalDamage(this, tarter);
		}

		private double GetBaseHitDamage()
		{
			var attack = GetStat(StatKind.Attack);
			var attackPower = GetStat(StatKind.AttackPower);

			return attack * attackPower;
		}


        public override Point GetWontPointToMove()
		{
			return _playerController.GetWontPosition(Position);
		}

		public static Player CreatePlayer(
			double health = 100
			, double attack = 2
			, double attackPower = 2
			, double defence = 10)
		{
			return new Player(new DummyLogger(), new UserController())
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
