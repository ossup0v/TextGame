using System.Collections.Generic;
using TextGame.Ammunition;

namespace TextGame.Inventory.Ammunition.Weapons
{
    public class SwordTest : AmmunitionBase
    {
        public SwordTest() : base(AmmunitionSlotKind.Weapon1, 'S')
        {
            Stats = new Dictionary<StatKind, double>()
            {
                [StatKind.Attack] = 10,
            };
        }
    }
}