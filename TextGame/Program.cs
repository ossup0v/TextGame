using System;
using TextGame.Characters;
using TextGame.Common;
using TextGame.Controllers;
using TextGame.UI;

namespace TextGame
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;

			var game = new GameController(Player.CreatePlayer());
			game.StartGame();

            Console.ReadLine();
		}
	}
}
