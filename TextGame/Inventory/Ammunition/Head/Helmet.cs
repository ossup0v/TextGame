using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Ammunition.Head
{
    public class Helmet : AmmunitionBase
    {
        public Helmet() : base(AmmunitionSlotKind.Head, 'H')
        {
            Stats = new Dictionary<StatKind, double>()
            {
                [StatKind.Armor] = 2,
                [StatKind.Defence] = 2,
            };
        }
    }
}
