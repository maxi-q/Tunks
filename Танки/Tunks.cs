using System;
using System.Collections.Generic;
using System.Text;

namespace Танки
{
    public abstract class Tunks
    {
        public string Name { get; set; }
        public int Cal { get; set; }
        public int Leyght { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public int Protection { get; set; }
        public int Shild { get; set; }
        public int Dod { get; set; }
        public int Power { get;  set; }

        public object[] ammos = new object[30]; //Чтобы одинаковое кол-во снарядов - кратно кол-ву видам снарядов (3)


        protected Tunks() 
        {
            Name = "Unknown";
            Protection = 0;
            Cal = 0;
            Leyght = 0;
            HP = 1;
            Shild = 0;
            Power = 0;
            Dod = 0;
            Type = "None";
        }

        protected Tunks(string _name)
        {
            Name = _name;
        }

        public abstract void Info();
}

    class LT : Tunks
    {

        public LT(string name) : base(name)
        {
            Protection = 10;
            Cal = 10;
            Leyght = 80;
            Dod = 30;
            HP = 400;
            Type = "ЛТ";
        }

        public override void Info()
        {
            Console.WriteLine("ЛТ");
            Console.WriteLine($"Твоё имя: {Name}\n" +
                              $"Калибр: {Cal}\n" +
                              $"Длинна ствола: {Leyght}\n" +
                              $"Маневренность: {Dod}\n");
        }


    }

    class PT : Tunks
    {

        

        public PT(string name) : base(name)
        {
            Protection = 15;
            Cal = 70;
            Leyght = 90;
            Power = 40;
            HP = 500;
            Type = "ПТ";
        }

        public override void Info()
        {
            Console.WriteLine("ПТ");
            Console.WriteLine($"Твоё имя: {Name}\n" +
                              $"Калибр: {Cal}\n" +
                              $"Длинна ствола: {Leyght}\n" +
                              $"Мощь: {Power}\n");
        }
    }

    class TT : Tunks
    {
        public int FullHP { get; private set; }

        public TT(string name) : base(name)
        {
            Protection = 20;
            Cal = 50;
            Leyght = 70;
            Shild = 20;
            FullHP = 600;
            HP = Shild + FullHP;

            Type = "ТТ";
        }

        public override void Info()
        {
            Console.WriteLine("ТТ");
            Console.WriteLine($"Твоё имя: {Name}\n" +
                              $"Калибр: {Cal}\n" +
                              $"Длинна ствола: {Leyght}\n" +
                              $"Доп.броня: {Shild}\n");
        }
    }

}
