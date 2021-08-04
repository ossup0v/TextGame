using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Inventory;
using TextGame.Map;

namespace TextGame.UI
{
    public class InventoryUI
    {
        public void ShowInventory(CharacterInventoryContainer inventory)
        {
            ConsoleManager.ClearConsole();

            var counter = 1;
            foreach (var ammunition in inventory.DressedAmmunition.Values)
            {
                ConsoleManager.ShowSymbol(ammunition.Symbol, new Point(counter,1));
                counter++;
            }

            counter = 1;
            foreach (var item in inventory.Inventory)
            {
                ConsoleManager.ShowSymbol(item.Symbol, new Point(counter,2));
                counter++;
            }

            ConsoleManager.GetKey();
        }
    }
}
