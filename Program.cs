using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int TrapPositionX;
            int TrapPositionY;
            int MaxRandom = 1;
            int nextPalier = 2;
            bool Lost = false;
            string Touches = "Déplacements: ↑ ↓ → ←\tInventaire : i\tCraft : c";
            Map World = new Map(24, 55);
            Hero MainCharacter = new Hero(World);
            List<Trap> TrapList = new List<Trap>();
            Monster[] MonsterArray = { new Bat(), new Wolf(), new Dragon() };
            FinalBoss FinalOvyn = new FinalBoss();

            for(int i = 0; i < 3; i++)
            {
                do
                {
                    TrapPositionX = random.Next(1, 24);
                    TrapPositionY = random.Next(1, 55);
                } while (World.WorldMap[TrapPositionX, TrapPositionY] != " ");
                TrapList.Add(new Hole(TrapPositionX, TrapPositionY));
            }
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    TrapPositionX = random.Next(1, 24);
                    TrapPositionY = random.Next(1, 55);
                } while (World.WorldMap[TrapPositionX, TrapPositionY] != " ");
                TrapList.Add(new Chest(TrapPositionX, TrapPositionY, (ItemType)random.Next(0, 2)));
            }
            for (int i = 2; i < 6; i++)
            {
                TrapPositionX = random.Next(1, 24);
                TrapPositionY = random.Next(1, 55);
                TrapList.Add(new Chest(TrapPositionX, TrapPositionY, (ItemType)i));
            }
            if (MainCharacter.Name != "Ovyn")
            {
                Console.WriteLine($"Le royaume de Shorewood a besoin de l'aide de {MainCharacter.Name}. De viles créatures ont pris possession de la grande forêt leur permettant de contacter" +
                    $"les royaumes voisins. Ces crétures sont menées par l'infâme Ovyn !!! {MainCharacter.Name} doit donc gagner en puissance pour occire ce terrible ennemi !");
                Console.ReadKey();
                if (MainCharacter.Race == "Humain")
                {
                    Console.WriteLine($"{MainCharacter.Name} fait partie de la race des {MainCharacter.Race}s et est donc doté d'une certaine connaissance de la magie." +
                        $"Cela pourra lui être utile face à certains ennemis sensibles...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (MainCharacter.Race == "Nain")
                {
                    Console.WriteLine($"{MainCharacter.Name} fait partie de la race des {MainCharacter.Race}s et est donc doté d'une plus grand force que la moyenne des être vivants." +
                        $"Sa connaissance des créature maléfiques lui permets d'analyser leurs caractéristiques.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine($"L'infâme {MainCharacter.Name} à conquis la grande forêt du royaume de Shorewood avec son armée de viles créatures.");
                Console.ReadKey();
                Console.WriteLine($"Mais attendez... Vous êtes l'infâme {MainCharacter.Name} !!!");
                Console.ReadKey();
                Lost = true;
            }

            while (!Lost)
            {
                if(MainCharacter.Level > nextPalier && MaxRandom < 4)
                {
                    MaxRandom++;
                    nextPalier *= 2;
                }
                Console.WriteLine(Touches);
                foreach (Trap trap in TrapList)
                {
                    World.WorldMap[trap.Position[0], trap.Position[1]] = trap.Avatar;
                    if (trap.Position[0] == MainCharacter.Position[0] && trap.Position[1] == MainCharacter.Position[1])
                    {
                        trap.TrapEffect(MainCharacter);
                        if (MainCharacter.IsDead())
                        {
                            Lost = true;
                        }
                    }
                }
                World.WorldMap[MainCharacter.Position[0], MainCharacter.Position[1]] = MainCharacter.Avatar;

                World.DrawMap();
                MainCharacter.ShowStats();

                if (MainCharacter.CanFight)
                {
                    if (MainCharacter.Level < 6)
                    {
                        World.RandomFight(MainCharacter, MonsterArray[random.Next(0, MaxRandom)], Touches);
                        if (MainCharacter.IsDead())
                        {
                            Console.ReadKey();
                            Lost = true;
                        }
                    }
                    else
                    {
                        World.RandomFight(MainCharacter, FinalOvyn, Touches);
                        if(!MainCharacter.IsDead())
                        {
                            Lost = true;
                        }
                    }    
                }

                if (!Lost)
                {
                    MainCharacter.Move(World);
                }

                Console.Clear();
            }
            //Fin de la boucle
            if(MainCharacter.IsDead())
            {
                Console.WriteLine($"{MainCharacter.Name} n'a pas pu sauver la forêt de Shorewood et est mort en vain.");
            }
            else if(MainCharacter.Name != "Ovyn" && !MainCharacter.IsDead())
            {
                Console.WriteLine($"{MainCharacter.Name} a sauvé la forêt de Shorewood de l'infâme Ovyn et don armée de monstres qui l'avaient envahi.\nLe nom de {MainCharacter.Name}" +
                    $" est entré dans l'histoire et ses descendants ne connaîtront jamais la faim.");
                Console.ReadKey();
                Console.WriteLine("GAGNÉ");
            }
            else if(!MainCharacter.IsDead())
            {
                Console.WriteLine($"Jamais aucun héro ne viendra tenter de vous occire... Votre domination s'étendra au-delà des frontières du royaume de Shorewood..." +
                    $"Tout cela pour vous rendre compte que malgré tout, comme les autres, vous n'êtes rien, et vous mourrez comme tout le monde, sans rien emporter dans l'au-delà...");
                Console.ReadKey();
                Console.WriteLine("GAGNÉ");
            }
            Console.ReadKey();
        }
    }
}