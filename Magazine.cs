using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Magazine
    {
        string name;
        int size;
        List<Ammo> ammos;

        public Magazine(string name, int size, List<Ammo> ammos)
        {
            this.name = name;
            this.size = size;
            this.ammos = ammos;
        }

        public Magazine(string name, int size, Ammo ammo)
        {
            this.name = name;
            this.size = size;
            this.ammos = new List<Ammo>();
            for (int i = 0; i < size; i++)
            {
                ammos.Add(ammo.Copy());
            }
        }

        public Ammo GetAmmo()
        {
            if (ammos.Count > 0)
            {
                Ammo ammoToReturn = ammos[ammos.Count - 1];
                ammos.RemoveAt(ammos.Count - 1);
                return ammoToReturn;
            }   
            else
                return null;
        }

        public void addAmmo(Ammo ammo)
        {
            if (ammos.Count < size)
                ammos.Append(ammo);
        }
        
        public override string ToString()
        {
            string output = name;
            output += " [" + ammos.Count + "/" + size + "]";
            foreach (Ammo ammo in ammos)
            {
                output += "\n" + ammo.ToString();
            }
            return output;
        }

        public Magazine Copy()
        {
            Magazine magazine = new Magazine(name, size, new List<Ammo>());
            for (int i = 0; i < ammos.Count; i++)
            {
                magazine.addAmmo(ammos[i].Copy());
            }
            return magazine;
        }
    }
}
