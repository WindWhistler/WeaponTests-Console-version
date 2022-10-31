using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Ammo
    {
        string name;
        private int damage;
        private int piercingClass;
        private int accuracyModifier;

        public Ammo(string name, int damage, int piercingClass, int accuracyModifier)
        {
            this.name = name;
            this.damage = damage;
            this.piercingClass = piercingClass;
            this.accuracyModifier = accuracyModifier;
        }

        public int Damage { get => damage; }
        public int AccuracyModifier { get => accuracyModifier; }
        public int PiercingClass { get => piercingClass; }

        public override string ToString()
        {
            return name + " " + 
                damage + " " +
                piercingClass + "/" + accuracyModifier;
        }

        public Ammo Copy()
        {
            return new Ammo(name, damage, piercingClass, accuracyModifier);
        }
    }
}
