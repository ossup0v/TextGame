using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Ammunition.Head;
using TextGame.Attacks;
using TextGame.Attacks.PhysicsAttacks;
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

			ChangeBaseStat(StatKind.Health, damage, ActionKind.Decreace);
		}

		public override void UseAttackToTarget(Character tarter)
        {
			while (true)
			{
				var wontAttack = _playerController.GetWontAttack(AvailableAttacks);

				if (wontAttack == null)
					ConsoleManager.LogError("Игрок смог не выбирать атаку");

				if (wontAttack.TryUseAttack(tarter))
					return;
			}
		}

        public override Point GetWontPointToMove()
		{
			return _playerController.GetWontPosition(Position);
		}

		public static Player CreatePlayer(
			double health = 100
			, double attack = 2
			, double attackPower = 2
			, double defence = 10
			, double physicsAttackPower = 2
			, double magicAttackPower = 2
			, double mp = 20)
        {

            var player = new Player(new DummyLogger(), new UserController());
			player
				.AddAttacks(new DefaultPhysicAttack(player), new FireBallSpell(player))
				.SetBaseStat(
					(StatKind.Health, health)
					, (StatKind.Attack, attack)
					, (StatKind.AttackPower, attackPower)
					, (StatKind.Defence, defence)
                    , (StatKind.PhysicsAttackPower, physicsAttackPower)
                    , (StatKind.MagicAttackPower, magicAttackPower)
                    , (StatKind.MP, mp))
				.SetBaseAmmunition(new Helmet());
			
			return player;
		}
	}
}
