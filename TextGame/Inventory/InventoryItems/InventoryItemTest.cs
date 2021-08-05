namespace TextGame.Inventory.InventoryItems
{
    public class InventoryItemTest : InventoryItemBase
    {
        public InventoryItemTest() : base('T')
        {
        }

        public override string GetDescription()
        {
            return $"{GetType().Name}: test";
        }
    }
}