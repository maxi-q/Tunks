using System;
using System.Collections.Generic;
using System.Text;

namespace Танки
{
    abstract class Ammo
    {
        public string Name { get; set; }
        public int Penetration { get; set; }
        public int CofRicochet { get; set; }
        public int damage { get; set; }
        public int count { get; set; }

        protected Ammo() 
        {

            Name = "Unknown";
            count = 0;
            Penetration = 0;
            CofRicochet = 0;
            damage = 0;
            
        }

        protected Ammo(int _penetration, int _cofRicochet, string _name, int _count, int _damage) 
        {
            Name = _name;
            Penetration = _penetration;
            CofRicochet = _cofRicochet;
            count = _count;
            damage = _damage;
        }

        public abstract object Load();

        }

    class Explosive : Ammo
    {
        public Explosive()
        {            
            Name = "Фугас";
            count = 1;
            Penetration = 15;
            CofRicochet = 0;
            damage = 65;
        }

        public override object Load()
        {
            return new Explosive();
        }

    }
    class Piercing : Ammo
    {
        public Piercing()
        {
            Name = "ББ";
            count = 2;
            Penetration = 60;
            CofRicochet = 30;
            damage = 50;
        }

        public override object Load()
        {
            return new Piercing();
        }
    }
    class Subcaliberal : Ammo
    {
        public Subcaliberal()
        {
            Name = "Подкалиберные";
            count = 3;
            Penetration = 100;
            CofRicochet = 40;
            damage = 45;
        }
        public override object Load()
        {
            return new Subcaliberal();
        }
    }
    class Delete : Ammo
    {
        public Delete() { }
        public override object Load()
        {
            return new Delete();
        }
    }
}
