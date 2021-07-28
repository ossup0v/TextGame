using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Common;

namespace TextGame.Characters
{
	public class Player : Character
	{
		private ILogger _logger;
		public Player(ILogger logger)
		{
			_logger = logger;
		}

		public override char SymbolOnMap { get; protected set; }

		public override void FillDamage(double damage)
		{
			if (damage < 0)
			{
				_logger.Log($"{nameof(Player)} getting damage less then zero! {nameof(damage)}: {damage}");
			}

			Health = damage * ((100 - Defence) / 100) - Armor; //TODO! 
		}

		public override double GetPhysicalAttackDamageFinal()
		{

		}
	}
}
