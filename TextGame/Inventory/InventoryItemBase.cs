using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Inventory
{
    public abstract class InventoryItemBase
    {
        public char Symbol;
        public string Description;

        public InventoryItemBase(char symbol)
        {
            Symbol = symbol;
        }
    }
}
