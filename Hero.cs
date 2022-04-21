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

            Race = SetRace();

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
        public static string SetAvatar(Hero Character)
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
                        Character.Avatar = "☺";
                        error = false;
                        break;
                    case '2':
                        Character.Avatar = "☻";
                        error = false;
                        break;
                    case '3':
                        Character.Avatar = "♥";
                        error = false;
                        break;
                    default:
                        break;
                }
            } while (error);

            return Character.Avatar;
        }
        public static void ShowStats(Hero Character)
        {
            Console.WriteLine($"Nom: {Character.Name}\nRace: {Character.Race}\nForce: {Character.Force}\nEndurance {Character.Endurance}\nPV: {Character.PV}");
        }
        public static void Move(Hero Character, Map world)
        {
            bool error = false;
            do
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Character.Position[0] == 1)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[Character.Position[0], Character.Position[1]] = " ";
                            Character.Position[0]--;
                        }
                        error = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Character.Position[0] == world.WorldMap.GetLength(0) - 2)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[Character.Position[0], Character.Position[1]] = " ";
                            Character.Position[0]++;
                        }
                        error = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Character.Position[1] == 1)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[Character.Position[0], Character.Position[1]] = " ";
                            Character.Position[1]--;
                        }
                        error = false;
                        break;
                    case ConsoleKey.RightArrow:
                        if (Character.Position[1] == world.WorldMap.GetLength(1) - 2)
                        {
                            Console.WriteLine("Il y a un mur devant de le héros, impossible d'avancer.");
                            Console.ReadKey();
                        }
                        else
                        {
                            world.WorldMap[Character.Position[0], Character.Position[1]] = " ";
                            Character.Position[1]++;
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