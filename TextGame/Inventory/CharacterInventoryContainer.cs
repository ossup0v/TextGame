using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Ammunition;
using TextGame.UI;

namespace TextGame.Inventory
{
    public class CharacterInventoryContainer
    {
        private Dictionary<AmmunitionSlotKind, AmmunitionBase> _dressedAmmunition = new Dictionary<AmmunitionSlotKind, AmmunitionBase>();
        public IReadOnlyDictionary<AmmunitionSlotKind, AmmunitionBase> DressedAmmunition => _dressedAmmunition;

        private List<InventoryItemBase> _inventory = new List<InventoryItemBase>();

        public IReadOnlyList<InventoryItemBase> Inventory => _inventory;

        public void AddToInventory(InventoryItemBase item)
        {
            if(Inventory == null)
            {
                ConsoleManager.LogError($"DonAmmunitionOnSlot: Inventory == null");
                return;
            }
            
            _inventory.Add(item);
        }

        public void DonAmmunitionOnSlot(AmmunitionBase ammunition)
        {
            if(DressedAmmunition == null)
            {
                ConsoleManager.LogError($"DonAmmunitionOnSlot: DressedAmmunition == null");
                return;
            }
            
            _dressedAmmunition[ammunition.Slot] = ammunition;
        }

        public void DonAmmunitionOnSlot(int inventoryIndex)
        {
            if(DressedAmmunition == null)
            {
                ConsoleManager.LogError($"DonAmmunitionOnSlot: DressedAmmunition == null");
                return;
            }

            if(Inventory == null)
            {
                ConsoleManager.LogError($"DonAmmunitionOnSlot: Inventory == null");
                return;
            }

            if (Inventory.Count < inventoryIndex)
            {
                ConsoleManager.LogError($"DonAmmunitionOnSlot: Inventory.Count {Inventory.Count}, inventoryIndex {inventoryIndex}");
                return;
            }

            var targetItem = Inventory[inventoryIndex];

            if (targetItem is AmmunitionBase targetAmmunition)
                _dressedAmmunition[targetAmmunition.Slot] = targetAmmunition;
            else
                ConsoleManager.LogError($"DonAmmunitionOnSlot: targetItem !is AmmunitionBase");
        }
    }
}
