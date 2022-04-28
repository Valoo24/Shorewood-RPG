using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Hero : Character
    {
        #region Attributs
        public string Race;
        public float Bonus;
        public int StepCount;
        public int NextLevel;
        public bool CanFight;
        public List<Item> Inventaire;
        #endregion
        #region constructeur
        public Hero(Map Map)
        {
            Level = 1;
            EXP = 0;
            NextLevel = 100;
            StepCount = 0;
            chance = rand.Next(4, 6);
            Force = throwDice(chance);
            Endurance = throwDice(chance);

            switch(chance)
            {
                case 4:
                    Bonus = 2.0f;
                    break;
                case 5:
                    Bonus = 1.5f;
                    break;
            }

            Console.WriteLine("Veuillez saisir le nom de votre héros.");
            Name = Console.ReadLine();
            Race = SetRace();
            Avatar = "☻";

            MaxPV = (int)((Endurance + chance) * Bonus);
            PV = MaxPV;

            CanFight = true;

            this.Position[0] = Map.WorldMap.GetLength(0) / 2;
            this.Position[1] = Map.WorldMap.GetLength(1) / 2;

            Inventaire = new List<Item>();
            Inventaire.Add(new Item(ItemType.Potion, 2));
        }
        #endregion
        #region Méthodes
        public string SetRace()
        {
            bool error = true;

            do
            {
                Console.WriteLine("Veuillez sélectionner la race de votre héros.");
                Console.WriteLine("<1> Humain \t<2> Nain");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Votre héros est un humain.");
                        this.Force += 1;
                        this.Endurance += 2;
                        this.Race = "Humain";
                        error = false;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '2':
                        Console.WriteLine("Votre héros est un nain.");
                        this.Force += 3;
                        this.Race = "Nain";
                        error = false;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Erreur, la touche saisie n'est pas valide !");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (error);

            return this.Race;
        }
        public void ShowStats()
        {
            Console.WriteLine($"Nom: {this.Name}\t Niveau: {this.Level}\n" +
                $"PV: {this.PV} / {this.MaxPV}\t Force: {this.Force}\t Endurance: {this.Endurance}\t Chance: {this.chance}\n" +
                $"Race: {this.Race}\t Niveau Suivant: {this.NextLevel - this.EXP} EXP");
        }
        public void Move(Map world)
        {
            bool error = false;
            do
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (this.Position[0] == 1)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[this.Position[0], this.Position[1]] = " ";
                            this.Position[0]--;
                        }
                        error = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (this.Position[0] == world.WorldMap.GetLength(0) - 2)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[this.Position[0], this.Position[1]] = " ";
                            this.Position[0]++;
                        }
                        error = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (this.Position[1] == 1)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[this.Position[0], this.Position[1]] = " ";
                            this.Position[1]--;
                        }
                        error = false;
                        break;
                    case ConsoleKey.RightArrow:
                        if (this.Position[1] == world.WorldMap.GetLength(1) - 2)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[this.Position[0], this.Position[1]] = " ";
                            this.Position[1]++;
                        }
                        error = false;
                        break;
                    case ConsoleKey.I:
                        OpenInventory();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.C:
                        CraftMenu();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("La touche saisie n'est pas bonne");
                        error = true;
                        break;
                }
            } while (error);
            this.CanFight = true;
        }
        public void OpenInventory(Monster Mob)
        {
            int i = 1;
            int choice = 0;
            string choicetext;
            if (this.Inventaire.Count > 0)
            {
                Console.WriteLine("Sélectionnez un objet de votre invenaire à utiliser (Appuyez sur \"Enter\" pour confirmer).");
                foreach (Item item in this.Inventaire)
                {
                    Console.Write($"{i}.{item.TypeOfItem} X {item.Quantity}\t");
                    i++;
                }
                Console.WriteLine();
                Console.Write("Objet sélectionné: ");
                choicetext = Console.ReadLine();
                if (Int32.TryParse(choicetext, out choice))
                {
                    choice = Int32.Parse(choicetext) - 1;
                    if (choice < this.Inventaire.Count)
                    {
                        this.Inventaire[choice].ItemEffect(this, Mob);
                    }
                    else
                    {
                        Console.WriteLine($"l'idiotie de {this.Name} l'empêche d'agir.");
                    }
                }
                else
                {
                    Console.WriteLine($"votre idiotie empêche {this.Name} d'agir.");
                }
            }
            else
            {
                Console.WriteLine($"L'inventaire de {this.Name} est vide...");
            }
        }
        public void OpenInventory()
        {
            int i = 1;
            int choice = 0;
            string choicetext;
            if (this.Inventaire.Count > 0)
            {
                Console.WriteLine("Sélectionnez un objet de votre invenaire à utiliser (Appuyez sur \"Enter\" pour confirmer).");
                foreach (Item item in this.Inventaire)
                {
                    Console.Write($"{i}.{item.TypeOfItem} X {item.Quantity}\t");
                    i++;
                }
                Console.WriteLine();
                Console.Write("Objet sélectionné: ");
                choicetext = Console.ReadLine();
                if (Int32.TryParse(choicetext, out choice))
                {
                    choice = Int32.Parse(choicetext) - 1;
                    if (choice < this.Inventaire.Count)
                    {
                        this.Inventaire[choice].ItemEffect(this);
                    }
                    else
                    {
                        Console.WriteLine($"La touche saisie incorrecte");
                    }
                }
                else
                {
                    Console.WriteLine($"La touche saisie est incorrecte");
                }
            }
            else
            {
                Console.WriteLine($"L'inventaire de {this.Name} est vide...");
            }
        }
        public void CraftMenu()
        {
            int NbrOfLeather = 0;
            string BonusText = "";
            foreach(Item item in this.Inventaire)
            {
                if(item.TypeOfItem == ItemType.Cuir)
                {
                    NbrOfLeather = item.Quantity;
                }
            }
            if(NbrOfLeather >= 1)
            {
                Console.WriteLine("Choisissez l'objet que vous voulez fabriquer.");
                for (int i = 2; i < 6; i++)
                {
                    if(i == 2)
                    {
                        BonusText = "Force + 4";
                    }
                    if(i == 3)
                    {
                        BonusText = "Endurance + 4";
                    }
                    if(i == 4)
                    {
                        BonusText = "PV + 25";
                    }
                    if(i == 5)
                    {
                        BonusText = "Chance + 4";
                    }
                    Console.Write($"{i - 1}. {(ItemType)i}({BonusText})\t");
                }
                Console.WriteLine();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{this.Name} n'a pas les objets nécessaires pour créer de l'équipement.");
            }
        }
        #endregion
    }
}