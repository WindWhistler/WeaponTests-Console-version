using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Armor
    {
        int armorClass;
        int maxDurability;
        int currentDurability;

        public double GetArmorReduction(Ammo ammo)
        {
            if (currentDurability == 0)
                return 1;
            int diff = ammo.PiercingClass - armorClass;
            if (diff < 0)
                return 1;
            if (diff == 0)
                return 0.66;
            if (diff == 1)
                return 0.33;
            if (diff > 1)
                return 0.16;
            return 0;
        }

        public override string ToString()
        {
            return "Class:" + armorClass + " Durability:" + currentDurability + "/" + maxDurability;
        }
    }
}
