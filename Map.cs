using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Map
    {
        #region Attributs
        public string[,] WorldMap = new string[256, 256];
        #endregion
        #region Méthodes
        /// <summary>
        /// Initialise la carte du monde. Pour dessiner la carte du monde, il faut uiliser la méthode d'instance DrawMap()
        /// </summary>
        /// <param name="LineSize">Nombre de lignes qui composent le tableau de la carte du monde. Représente sa "hauteur".</param>
        /// <param name="RowSize">Nombre de colonnes qui composent le tableau de la carte du monde. Représente sa "largeur".</param>
        /// <returns>Le tableau représentant la carte du monde.</returns>
        public string[,] InitializeMap(int LineSize, int RowSize)
        {
            string[,] map = new string[LineSize,RowSize];

            for (int i = 0; i < LineSize; i++)
            {
                for (int j = 0; j < RowSize; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        map[i, j] = "╔";
                    }
                    else if (i == 0 && j == RowSize - 1)
                    {
                        map[i, j] = "╗";
                    }
                    else if (i == LineSize - 1 && j == 0)
                    {
                        map[i, j] = "╚";
                    }
                    else if (i == LineSize - 1 && j == RowSize - 1)
                    {
                        map[i, j] = "╝";
                    }
                    else if ((i == 0 || i == LineSize - 1) && (j > 0 && j < RowSize - 1))
                    {
                        map[i, j] = "═";
                    }
                    else if ((j == 0 || j == RowSize - 1) && (i > 0 && i < LineSize - 1))
                    {
                        map[i, j] = "║";
                    }
                    else
                    {
                        map[i, j] = " ";
                    }
                }
            }

            return map;
        }
        /// <summary>
        /// Dessine la carte du monde dans la console.
        /// </summary>
        public void DrawMap()
        {
            for (int i = 0; i < this.WorldMap.GetLength(0); i++)
            {
                for(int j = 0; j < this.WorldMap.GetLength(1); j++)
                {
                    Console.Write(this.WorldMap[i, j]);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Initialise un combat de manière aléatoire selon un lancé de dé basé sur la chance du Héros. Si ce lancé de dé est inférieur au compteur de pas du héros, alors un combat
        /// se lance.
        /// </summary>
        /// <param name="Character">Instance du Héros du jeu</param>
        /// <param name="Mob">Instance du monstre que le héros risque de combattre</param>
        public void RandomFight(Hero Character, Monster Mob)
        {
            if(Character.throwDice(1) < Character.StepCount)
            {
                this.Battle(Character, Mob);
                if (!Character.IsDead())
                {
                    Console.WriteLine();
                    this.DrawMap();
                    Character.StepCount = 0;
                }
            }
            else
            {
                Character.StepCount++;
            }
        }
        /// <summary>
        /// Lance l'écran et le menu de combat. Toute la phase de combat se fait dans cette méthode.
        /// </summary>
        /// <param name="Character">Instance du héros qui va combattre</param>
        /// <param name="Mob">Instance du monstre à combattre</param>
        public void Battle(Hero Character, Monster Mob)
        {
            int r = 0;
            bool stop = false;
            bool IsFlying = false;
            Console.Clear();
            Console.WriteLine($"Vous tombez sur {Mob.Name} !!!");
            Console.ReadKey();
            Console.WriteLine();
            do
            {
                Character.ShowStats();
                #region BattleMenu
                Console.WriteLine(@"
 -------------   -----------   -----------   -----------
| <1> Attaque | | <2> Magie | | <3> Objet | | <4> Fuite |
 -------------   -----------   -----------   -----------");
                #endregion
                Console.WriteLine(Mob.ASCII);
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                switch(cki.KeyChar)
                {
                    case '1':
                        Character.Attack(Mob);
                        if (Mob.IsDead())
                        {
                            Console.WriteLine($"Vous avez tué {Mob.Name}!");
                            // Mettre ici le code d'obtention d'expérience et de gain de niveau / stats
                            Character.EXP += Mob.EXP;
                            if(Character.EXP >= Character.NextLevel)
                            {
                                Console.WriteLine($"Wow ! {Character.Name} Monte d'un niveau !");
                                r = Character.rand.Next(1, 2);
                                switch (Character.rand.Next(1, 4))
                                {
                                    case 1:
                                        Character.Force += r;
                                        break;
                                    case 2:
                                        Character.Endurance += r;
                                        break;
                                    case 3:
                                        Character.chance += 1;
                                        break;
                                    case 4:
                                        Character.Force += r;
                                        Character.Endurance += r;
                                        Character.chance += 1;
                                        break;
                                }
                            }
                            stop = true;
                        }
                        break;
                    case '2': //Insérer Script du choix de Magie
                        break;
                    case '3': //Insérer Script du choix d'objet dans l'inventaire
                        break;
                    case '4':
                        Console.WriteLine("Vous fuyez comme un pleutre !");
                        switch(Character.throwDice(1) / 2)
                        {
                            case 1:
                                Console.WriteLine("En prenant la fuite, votre endurance en a pris un coup.");
                                Character.Endurance -= 1;
                                break;
                            case 2:
                                Console.WriteLine("La panique vous a fait perdre un peu de votre force.");
                                Character.Force -= 1;
                                break;
                            default:
                                Console.WriteLine("Coup de bol, vous fuyez sain et sauf !");
                                break;
                        }
                        stop = true;
                        IsFlying = true;
                        break;
                    default:
                        Console.WriteLine("Votre idiotie vous empêche d'agir.");
                        break;
                }
                Console.ReadKey();
                Console.WriteLine();
                if(!Mob.IsDead() && !IsFlying)
                {
                    Mob.Attack(Character);
                    Console.ReadKey();
                    Console.WriteLine();
                }
                if(Character.IsDead())
                {
                    stop = true;
                    Console.WriteLine($"{Mob.Name} vous a tué. Vous êtes mort dans l'indifférence totale...");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                Console.Clear();
            } while (!stop);
        }
        #endregion
    }
}