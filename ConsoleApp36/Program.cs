using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    internal class Program
    {
        public abstract class Business
        {
            public string Person { get; set; }
            public int Damage { get; set; }
            public int Pace { get; set; }
            public int Healf { get; set; }
            public int Security { get; set; }
            public abstract string Operation();
            public string ToString()
            {
                return $"Profession name{Person}\nAttack{Damage}\nSpeed{Pace}\nHealth{Healf}\nProtection{Security}";
            }
        }
        class Man : Business
        {

            public override string Operation()
            {
                Person = "Man";
                Damage += 20;
                Pace += 20;
                Healf += 150;
                Security += 0;
                return ToString();
            }
        }
        class Elfe : Business
        {
            public override string Operation()
            {
                Person = "Elfe";
                Damage += 15;
                Pace += 30;
                Healf += 100;
                Security += 0;
                return ToString();
            }
        }
        abstract class Painter : Business
        {
            protected Business prof;

            public Painter(Business prof)
            {
                this.prof = prof;
            }

            public void SetProfesssion(Business prof)
            {
                this.prof = prof;
            }
            public override string Operation()
            {

                if (prof != null)
                    return ToString();
                else
                    return null;
            }
        }

        class Man_Warrior : Man
        {
            public Man_Warrior(Man Persone)
            {
                Person = "Man_Warrior";
                Damage += 20;
                Pace = Persone.Pace + 10;
                Healf = Persone.Healf + 50;
                Security = Persone.Security + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Swordsman : Man
        {
            public Swordsman(Man_Warrior Persone)
            {
                Person = "Swords_man";
                Damage = Persone.Damage + 40;
                Pace = Persone .Pace - 10;
                Healf = Persone.Healf + 50;
                Security = Persone.Security + 40;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Archer : Man
        {
            public Archer(Man_Warrior Persone)
            {
                Person = "Archer";
                Damage = Persone.Damage + 20;
                Pace = Persone.Pace + 20;
                Healf = Persone.Healf + 50;
                Security = Persone.Security + 10;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Rider : Man
        {
            public Rider(Swordsman Persone)
            {
                Person = "Rider";
                Damage = Persone.Damage - 10;
                Pace = Persone.Pace + 40;
                Healf = Persone.Healf + 200;
                Security = Persone.Security + 100;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }

        class ElfWarrior : Elfe
        {
            public ElfWarrior(Elfe elf)
            {
                Person = "Elf_warior";
                Damage = elf.Damage + 20;
                Pace = elf.Pace - 10;
                Healf = elf.Healf + 100;
                Security = elf.Security + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class ElfMage : Elfe
        {
            public ElfMage(Elfe elf)
            {
                Person = "Elf_mag";
                Damage = elf.Damage + 10;
                Pace = elf.Pace + 10;
                Healf = elf.Healf - 50;
                Security = elf.Security + 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Crossbowman : Elfe
        {
            public Crossbowman(ElfWarrior elf)
            {
                Person = "Bowman";
                Damage   = elf.Damage + 20;
                Pace = elf.Pace + 10;
                Healf = elf.Healf + 50;
                Security = elf.Security - 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Evil_Mage : Elfe
        {
            public Evil_Mage(ElfMage elf)
            {
                Person = "Evil_mage";
                Damage = elf.Damage + 70;
                Pace = elf.Pace + 20;
                Healf = elf.Healf + 0;
                Security = elf.Security + 0;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Kind_Mage : Elfe
        {
            public Kind_Mage(ElfMage elf)
            {
                Person = "Kind_mage";
                Damage = elf.Damage + 50;
                Pace = elf.Pace + 30;
                Healf = elf.Healf + 100;
                Security = elf.Security + 30;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        public class Client
        {
            public void ClientCode(Business Professsion)
            {
                Console.WriteLine(Professsion.Operation());
            }
        }
        static void Main(string[] args)
        {
            Client client = new Client();
            Man human = new Man();
            client.ClientCode(human);
            Man_Warrior warrior = new Man_Warrior(human);
            client.ClientCode(warrior);
            Swordsman swordsman = new Swordsman(warrior);
            client.ClientCode(swordsman);
            Rider rider = new Rider(swordsman);
            client.ClientCode(rider);
            Elfe elf = new Elfe();
            client.ClientCode(elf);
            ElfWarrior warrior1 = new ElfWarrior(elf);
            client.ClientCode(warrior1);
            ElfMage mage = new ElfMage(elf);
            client.ClientCode(mage);
            Crossbowman crossbowman = new Crossbowman(warrior1);
            client.ClientCode(crossbowman);
            Evil_Mage evil = new Evil_Mage(mage);
            client.ClientCode(evil);
            Kind_Mage kind = new Kind_Mage(mage);
            client.ClientCode(kind);
        }
    }
}
