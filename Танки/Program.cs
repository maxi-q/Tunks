using System;

namespace Танки
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Play play = new Play();
            play.Game();
        }
    }

    public class Play
    {
        readonly Explosive Explosive = new Explosive();
        readonly Piercing Piercing = new Piercing();
        readonly Subcaliberal Subcaliberal = new Subcaliberal();
        readonly Delete Delete = new Delete();

        bool IsLoaded = false;
        
        public Tunks Enemy;
        public Tunks MyTunks;
        public string name = "Unkown";

        public  void Game()
        {
            name = InputName();
            while (true)
            {
                ChoiceYourTunk();
                ChargingAmmu();
                LoadedAmmu();
                Console.WriteLine("Продолжить играть? \n\t1 - да \n\t2 - нет");
                string i;
                while (true)
                {
                    i = Console.ReadLine();
                    if(i == "1"|| i == "2") { break; }
                }
                if (i == "1") {Console.Clear(); Console.WriteLine($"Твоё имя:\t{name}\n"); continue; } else { break; }

            }
        }

        private void LoadedAmmu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТы атакуешь!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nВыберите тип снаряда:\n" +
                                        $"\tФугас: {Explosive.count}\n" +
                                        $"\tБронебойные: {Piercing.count}\n" +
                                        $"\tПодкилиберы: {Subcaliberal.count}\n");
                while (true)
                {
                    IsLoaded = false;
                    Console.Write("Try Num: ");
                    string TryNum = Console.ReadLine();
                    int.TryParse(TryNum, out int shellNum);

                    for (int i = 0; i < MyTunks.ammos.Length; i++)
                    {
                        
                            if (MyTunks.ammos[i] != Delete)
                            {
                                if (shellNum == Explosive.count && MyTunks.ammos[i] == Explosive)
                                {
                                    Console.WriteLine("фугас");
                                    Shot("Explosive", i);
                                    IsLoaded = true;
                                }
                                if (shellNum == Piercing.count && MyTunks.ammos[i] == Piercing)
                                {
                                    Console.WriteLine("ББ");
                                    Shot("Piercing", i);
                                    IsLoaded = true;
                                }
                                if (shellNum == Subcaliberal.count && MyTunks.ammos[i] == Subcaliberal)
                                {
                                    Console.WriteLine("подкалибер");
                                     Shot("Subcaliberal", i);
                                    IsLoaded = true;
                                }
                            }
                            if (IsLoaded) break;
                    }
                    if (!IsLoaded) Console.WriteLine(" Нет снарядов ");
                    break;

                }
                if (Enemy.HP <= 0) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПОБЕДА!\n"); Console.ForegroundColor = ConsoleColor.White; break; }
                if (IsLoaded) {
                    Counterattack(); 
                    if (MyTunks.HP <= 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nТЫ ПРОИГРАЛ!!!\n"); Console.ForegroundColor = ConsoleColor.White; break; }
                }
                
            }

        }

        private void Counterattack()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nКонтр Атака!!!");
            Console.ForegroundColor = ConsoleColor.White;
            string[] ammos = { "Piercing", "Piercing", "Explosive" };

            Random random = new Random();
            int EnemyShot = random.Next(0, 3);
            string _ShellE = ammos[EnemyShot];

            Ammo ShellE = _ShellE switch
            {
                "Subcaliberal" => new Subcaliberal(),
                "Piercing" => new Piercing(),
                "Explosive" => new Explosive(),
                _ => new Delete(),
            };
            int damage = RicForENEMY(ShellE);

            MyTunks.HP -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Получено урона {damage}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \nОставшееся здоровье: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write( MyTunks.HP + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Shot(string _Shell, int i)
        {
            Ammo Shell = _Shell switch
            {
                "Subcaliberal" => new Subcaliberal(),
                "Piercing" => new Piercing(),
                "Explosive" => new Explosive(),
                _ => new Delete(),
            };
            Shell.damage += MyTunks.Power;
            MyTunks.ammos[i] = Delete;
            Console.WriteLine("выстрелить?\n\t1 - да\t2 - нет");
            int Choice;
            do
            {
                string j = Console.ReadLine();
                int.TryParse(j, out Choice);
            } while (Choice != 1 );

            Console.WriteLine("\n");

            int damage = RicForMy(Shell);

            Enemy.HP -= damage;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Нанесено урона {damage}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \nОставшееся здоровье врага: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Enemy.HP + "\n");
            Console.ForegroundColor = ConsoleColor.White;

            if (Enemy.Shild > 0) { Console.WriteLine($"Оставшаяся броня врага: { Enemy.Shild}"); }
            return;
        }

        private void ChargingAmmu()
        {
            object[] ammosType = new object[3] { Explosive, Piercing, Subcaliberal };
            int j = 0;
            foreach (object obj in ammosType)
            {
                for (int i = 0; i < MyTunks.ammos.Length / ammosType.Length; i++)
                {
                    MyTunks.ammos[j] = obj;
                    j++;
                }
            }
        }

        private void  ChoiceYourTunk()
        {
            string i;
            int d = 1;

            Console.Write("\nВыберите свой танк из предложенных:\n" +
                               "1 - легкий танк\n" +
                               "2 - тяжелый танк\n" +
                               "3 - ПТ-САУ\n" +
                               "Ваш Выбор: ");

            while (d != 0)
            {
                i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        MyTunks = new LT(name);
                        MyTunks.Info();
                        d = 0;
                        break;
                    case "2":
                        MyTunks = new TT(name);
                        MyTunks.Info();
                        d = 0;
                        break;
                    case "3":
                        MyTunks = new PT(name);
                        MyTunks.Info();
                        d = 0;
                        break;
                    default:
                        Console.Write("Ошибка, повторите еще раз: ");
                        break;

                }
            }

            Random random = new Random();
            string[] tunksType = new string[3] { "LT", "PT", "TT" };
            int rndTunk = random.Next(tunksType.Length);
            switch (rndTunk)
            {
                case 0:
                    Enemy = new LT("вражеский LТ");
                    break;
                case 1:
                    Enemy = new PT("вражеский PТ");
                    break;
                case 2:
                    Enemy = new TT("вражеский TT");
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Твой противник - {Enemy.Type}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private string InputName()
        {
            Console.Write("Введите своё имя: ");
            name = Console.ReadLine();
            return name;
        }

        private int RicForMy(Ammo Shell) 
        {
            Random random = new Random();

            int ricochet = random.Next(0, 100);
            if (ricochet < Shell.CofRicochet) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Рикошет :: {ricochet} "); Console.ForegroundColor = ConsoleColor.White; return 0; }
            Console.WriteLine($"            Рикошет :: {ricochet} ");

            int hit = random.Next(0, 100);
            if (hit > MyTunks.Leyght - Enemy.Dod) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Мимо! :: {hit}"); Console.ForegroundColor = ConsoleColor.White; return 0; }
            Console.WriteLine($"            Мимо :: {hit}");

            int Penetration = random.Next(Shell.Penetration - 3, Shell.Penetration + 4);
            if (Penetration < Enemy.Protection)
            {
                if (Shell.count == 1)
                {
                    if (Enemy.Shild > 0)
                    {
                        Enemy.Shild -= 10;
                        Shell.damage -= 10;
                        if (Enemy.Shild == 0)
                        {
                            Console.WriteLine("Щит разрушен!");
                        }
                    }
                    Shell.damage -= Enemy.Protection;
                }
                else { Console.WriteLine("Броня не пробита"); return 0; }

            }
            return Shell.damage;
        }

        private int RicForENEMY(Ammo Shell)
        {
            Random random = new Random();

            int ricochet = random.Next(0, 100);
            if (ricochet < Shell.CofRicochet) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Рикошет :: {ricochet} "); Console.ForegroundColor = ConsoleColor.White; return 0; }
            Console.WriteLine($"            Рикошет :: {ricochet} ");

            int hit = random.Next(0, 100);
            if (hit > Enemy.Leyght - MyTunks.Dod) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Мимо! :: {hit}"); Console.ForegroundColor = ConsoleColor.White; return 0; }
            Console.WriteLine($"            Мимо :: {hit}");

            int Penetration = random.Next(Shell.Penetration - 3, Shell.Penetration + 4);
            if (Penetration < MyTunks.Protection)
            {
                if (Shell.count == 1)
                {
                    if (MyTunks.Shild > 0)
                    {
                        MyTunks.Shild -= 10;
                        Shell.damage -= 10;
                        if (MyTunks.Shild == 0)
                        {
                            Console.WriteLine("Щит разрушен!");
                        }
                    }
                    Shell.damage -= MyTunks.Protection;
                }
                else { Console.WriteLine("Броня не пробита"); return 0; }

            }
            return Shell.damage;
        }

    }

}
