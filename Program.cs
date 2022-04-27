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
            int MaxRandom = 1;
            int nextPalier = 2;
            bool Lost = false;
            string Touches = "Déplacements: ↑ ↓ → ←";
            Hero MainCharacter = new Hero();
            Map World = new Map();

            World.WorldMap = World.InitializeMap(24, 55);

            MainCharacter.Position[0] = World.WorldMap.GetLength(0)/2;
            MainCharacter.Position[1] = World.WorldMap.GetLength(1)/2;

            Monster[] MonsterArray = { new Bat(MainCharacter), new Wolf(MainCharacter), new Dragon(MainCharacter) };

            Hole Hole1 = new Hole(World);

            while (!Lost)
            {
                if(MainCharacter.Level > nextPalier && MaxRandom < 4)
                {
                    MaxRandom++;
                    nextPalier *= 2;
                }
                Console.WriteLine(Touches);
                World.WorldMap[Hole1.Position[0], Hole1.Position[1]] = Hole1.Avatar;
                World.WorldMap[MainCharacter.Position[0], MainCharacter.Position[1]] = MainCharacter.Avatar;

                //Affiche la carte du monde.
                World.DrawMap();

                //Gère les interactions entre le héros et le pièges / ennemis.
                if (MainCharacter.Position[0] == Hole1.Position[0] && MainCharacter.Position[1] == Hole1.Position[1])
                {
                    Hole1.TrapEffect(MainCharacter);
                    if(MainCharacter.PV < 0)
                    {
                        MainCharacter.PV = 0;
                    }
                    Console.WriteLine($"Vous tombez dans le trou ! Vous perdez {Hole1.Damage} PV. Il vous reste {MainCharacter.PV} PV.");
                }
                else
                {
                    World.RandomFight(MainCharacter, MonsterArray[random.Next(0, MaxRandom)]);
                }

                if(MainCharacter.IsDead())
                {
                    Console.ReadKey();
                    Lost = true;
                }
                else
                {
                    //Gère tous les déplacements du jeu.
                    MainCharacter.Move(World);
                }

                Console.Clear();
            }
            if(MainCharacter.IsDead())
            {
                Console.WriteLine($"{MainCharacter.Name} n'a pas pu sauver la forêt de Shorewood et est mort en vain.");
            }
            else
            {
                Console.WriteLine($"{MainCharacter.Name} a sauvé la forêt de Shorewood de tous les infâmes monstres qui l'avaient envahi.\nLe nom de {MainCharacter.Name}" +
                    $" est entré dans l'histoire et ses descendants ne connaîtront jamais la faim.");
            }
            Console.ReadKey();
        }
    }
}