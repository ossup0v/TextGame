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
using TextGame.Inventory.Ammunition.Leggings;
using TextGame.Inventory.Ammunition.Weapons;
using TextGame.Map;
using TextGame.UI;

namespace TextGame.Characters
{
	public class Player : Character
	{
        private readonly IPlayerController _playerController;

        private Player(IPlayerController playerController)
		{
            _playerController = playerController;
            SymbolOnMap = Constants.PlayerChar;
			ChangeState(CharacterState.Walk);
		}

        public override void FillDamage(double damage)
		{
			if (damage < 0)
			{
                ConsoleManager.LogError($"{GetType().Name} getting damage less then zero! {nameof(damage)}: {damage}");
				return;
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
			, double mp = 10)
        {

            var player = new Player(new UserController());
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
				.SetBaseAmmunition();
			
			return player;
		}

		public override ConsoleKey GetKey()
		{
			return ConsoleManager.GetKey();
		}
	}
}
