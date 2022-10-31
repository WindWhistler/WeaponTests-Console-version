using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Weapon
    {
        string name;
        int shots;
        int accuracyModifier;

        Ammo loadedAmmo;
        Magazine magazine;

        public Weapon(string name, int shots, int accuracyModifier, Ammo loadedAmmo, Magazine magazine)
        {
            this.name = name;
            this.shots = shots;
            this.accuracyModifier = accuracyModifier;
            this.loadedAmmo = loadedAmmo;
            this.magazine = magazine;
        }

        public int Shoot(Token token, int bodyPart = 0, int externalModifier = 0)
        {
            //No real probability sadly
            //Also, probability is counted in 1/20 portions
            
            for (int i = 0; i < shots; i++)
            {
                LoadAmmo();

                double meanDamageModifier = 0;

                if (loadedAmmo != null)
                {
                    int hitProbability = Math.Max(Math.Min(
                    20 - 8 - 4 * bodyPart + accuracyModifier + externalModifier + loadedAmmo.AccuracyModifier + 1,
                    20), 0);
                    int criticalHitProbability = Math.Max(Math.Min(
                        20 - 16 + accuracyModifier + externalModifier + loadedAmmo.AccuracyModifier + 1,
                        20), 0);
                     meanDamageModifier = ((double)(hitProbability + criticalHitProbability * (bodyPart == 2 ? 2 : 1))) / 20;
                }

                token.TakeDamage(loadedAmmo, meanDamageModifier, bodyPart);
                loadedAmmo = null;
            }

            return 0;
        }

        public Magazine ChangeMagazine(Magazine newMagazine)
        {
            Magazine buf = magazine;
            magazine = newMagazine;
            return buf;
        }

        public void LoadAmmo()
        {
            if (loadedAmmo == null)
            {
                loadedAmmo = magazine.GetAmmo();
            }
        }

        public override string ToString()
        {
            return name + " " + shots + "/" + (accuracyModifier >= 0 ? "+" : "") + accuracyModifier +
                (loadedAmmo != null ? "\n" + loadedAmmo.ToString() : "") + 
                "\n" + magazine.ToString();
        }
    }
}
