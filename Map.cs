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
        public void DrawMap(string[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void Battle(Hero Character, Monster Mob)
        {
            int r = 0;
            bool stop = false;
            bool IsFlying = false;
            Console.Clear();
            Console.WriteLine($"Vous tombez sur {Mob.Name} !!!");
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
                            r = Mob.rand.Next(1, Mob.EXP);
                            Character.Force += r;
                            Console.WriteLine($"{Character.Name} gagne +{r} en force. La force de {Character.Name} est maintenant de {Character.Force}.");
                            r = Mob.rand.Next(1, Mob.EXP);
                            Character.Endurance += r;
                            Console.WriteLine($"{Character.Name} gagne +{r} en Endurance. L'endurance de {Character.Name} est maintenanr de {Character.Endurance}.");
                            stop = true;
                        }
                        break;
                    case '2': //Insérer Script du choix de Magie
                        break;
                    case '3': //Insérer Script du choix d'objet dans l'inventaire
                        break;
                    case '4':
                        Console.WriteLine("Vous fuyez comme un pleutre !");
                        switch(Character.throwDice(1)/2)
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