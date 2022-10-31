using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Token
    {
        string name;
        int hitPoints;
        int skill;

        Weapon mainWeapon;
        Armor helmet;
        Armor bodyArmor;
        List<Magazine> magazines;

        public Token(string name, int hitPoints, int skill, Weapon mainWeapon, Armor helmet, Armor bodyArmor, List<Magazine> magazines)
        {
            this.name = name;
            this.hitPoints = hitPoints;
            this.skill = skill;
            this.mainWeapon = mainWeapon;
            this.helmet = helmet;
            this.bodyArmor = bodyArmor;
            this.magazines = magazines;
        }

        public int HitPoints { get => hitPoints; }

        public void TakeDamage(Ammo ammo, double damageMultiplier, int bodyPart = 0)
        {
            if (ammo == null)
                return;
            else
            {
                double damage = ammo.Damage * damageMultiplier;
                if (bodyPart == 0)
                    damage *= bodyArmor != null ? bodyArmor.GetArmorReduction(ammo) : 1;
                if (bodyPart == 1)
                    damage *= 0.66;
                if (bodyPart == 2)
                    damage *= helmet != null ? helmet.GetArmorReduction(ammo) : 1;

                hitPoints -= (int)damage;
            }
        }

        public void Shoot(Token target, int bodyPart)
        {
            mainWeapon.Shoot(target, bodyPart, skill);
        }

        public void ChangeMagazine(int magazineId)
        {
            if(magazineId < magazines.Count)
                magazines[magazineId] = mainWeapon.ChangeMagazine(magazines[magazineId]);
        }

        public void LoadAmmo()
        {
            mainWeapon.LoadAmmo();
        }

        public string WeaponToString()
        {
            return mainWeapon.ToString();
        }

        public string MagazinesToString()
        {
            string output = "Your current magazines:";
            for (int i = 0; i < magazines.Count; i++)
            {
                output += "\n" + i + ": " + magazines[i].ToString();
            }
            return output;
        }

        public override string ToString()
        {
            return name + ": " + hitPoints + " HP/" + skill + " Skill";
        }

        public void AddMagazine(Magazine magazine)
        {
            magazines.Add(magazine);
        }

        public int InventorySize()
        {
            return magazines.Count;
        }
    }
}
