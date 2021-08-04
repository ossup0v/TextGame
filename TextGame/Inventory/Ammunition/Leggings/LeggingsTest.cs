using System.Collections.Generic;
using TextGame.Ammunition;

namespace TextGame.Inventory.Ammunition.Leggings
{
    public class LeggingsTest : AmmunitionBase
    {
        public LeggingsTest() : base(AmmunitionSlotKind.Leggings, 'L')
        {
            Stats = new Dictionary<StatKind, double>()
            {
                [StatKind.Armor] = 5,
                [StatKind.Defence] = 5,
            };
        }
    }
}