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
        public string[] Inventaire = new string[10];
        #endregion
        #region constructeur
        public Hero()
        {
            chance = 4;
            for (int i = 0; i < chance; i++)
            {
                Force += rand.Next(1, chance + 2);
            }

            for (int i = 0; i < chance; i++)
            {
                Endurance += rand.Next(1, chance + 2);
            }

            if (Force > 15)
            {
                Bonus = 2.5f;
            }
            else if (Force > 10)
            {
                Bonus = 2.0f;
            }
            else if (Force > 5)
            {
                Bonus = 1.5f;
            }
            else if (Force <= 5)
            {
                Bonus = 1.0f;
            }

            Console.WriteLine("Veuillez saisir le nom de votre héros.");
            Name = Console.ReadLine();
            Race = SetRace();
            Avatar = SetAvatar();

            PV = (int)(Endurance * Bonus);
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
                        this.Endurance += 1;
                        this.Race = "Humain";
                        error = false;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '2':
                        Console.WriteLine("Votre héros est un nain.");
                        this.Endurance += 2;
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
        public string SetAvatar()
        {
            bool error = true;
            do
            {
                Console.WriteLine("Sélectionnez un avatar pour votre personnage.");
                Console.WriteLine("<1> ☺\t<2> ☻\t<3> ♥");
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.KeyChar)
                {
                    case '1':
                        this.Avatar = "☺";
                        error = false;
                        break;
                    case '2':
                        this.Avatar = "☻";
                        error = false;
                        break;
                    case '3':
                        this.Avatar = "♥";
                        error = false;
                        break;
                    default:
                        break;
                }
            } while (error);

            return this.Avatar;
        }
        public void ShowStats()
        {
            Console.WriteLine($"Nom: {this.Name}\nRace: {this.Race}\nForce: {this.Force}\nEndurance {this.Endurance}\nPV: {this.PV}");
        }
        public void Move(Map world)
        {
            bool error = false;
            do
            {
                ConsoleKeyInfo cki = Console.ReadKey();
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
                    default:
                        Console.WriteLine("La touche saisie n'est pas bonne");
                        error = true;
                        break;
                }
            } while (error);
        }
        #endregion
    }
}