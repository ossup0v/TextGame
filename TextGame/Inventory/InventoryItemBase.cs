using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Inventory
{
    public abstract class InventoryItemBase
    {
        public char Symbol;
        public string Description;

        public abstract string GetDescription();

        public InventoryItemBase(char symbol)
        {
            Description = $"{this.GetType().Name}: test";
            Symbol = symbol;
        }
    }
}
