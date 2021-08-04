using System;
using System.Collections.Generic;
using System.Linq;
using TextGame.Ammunition.Head;
using TextGame.Inventory;
using TextGame.Inventory.Ammunition.Leggings;
using TextGame.UI;

namespace TextGame.Common
{
    public class SymbolItemMap
    {
        private static SymbolItemMap _instance;

        public static SymbolItemMap Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SymbolItemMap();

                return _instance;
            }
        }

        private SymbolItemMap()
        {
            var itemType = typeof(InventoryItemBase);
            var allItems = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => itemType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);
            
            foreach (var item in allItems)
            {
                var createdItem = (InventoryItemBase) Activator.CreateInstance(item);
                
                if (createdItem != null)
                    _getNewItem[createdItem.Symbol] = () =>  (InventoryItemBase) Activator.CreateInstance(item);
                else
                    ConsoleManager.LogError($"ctor {nameof(SymbolItemMap)} ERROR");
            }
        }

        private readonly Dictionary<char, Func<InventoryItemBase>> _getNewItem = new Dictionary<char, Func<InventoryItemBase>>();

        public IEnumerable<char> AllItemSymbols => _getNewItem.Keys;
        public InventoryItemBase GetItem(char itemSymbol)
        {
            if (_getNewItem.TryGetValue(itemSymbol, out var itemCreateFunc))
            {
                return itemCreateFunc();
            }
            else
            {
                ConsoleManager.LogError($"{nameof(GetItem)}: can't find item with symbol {itemSymbol}");
                return null;
            }
        }
    }
}