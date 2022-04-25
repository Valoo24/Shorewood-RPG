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
            
            bool Lost = false;
            string Touches = "Déplacements: ↑ ↓ → ←";
            Hero MainCharacter = new Hero();
            Bat Bat1 = new Bat();
            Wolf Wolf1 = new Wolf();
            Map World = new Map();
            Hole Hole1 = new Hole();

            World.WorldMap = World.InitializeMap(24, 55);

            MainCharacter.Position[0] = World.WorldMap.GetLength(0)/2;
            MainCharacter.Position[1] = World.WorldMap.GetLength(1)/2;

            while (!Lost)
            {
                //Hero.ShowStats(MainCharacter);
                Console.WriteLine(Touches);

                //Place tous les éléments sur la carte du monde.
                if(!Bat1.IsDead())
                {
                    World.WorldMap[Bat1.Position[0], Bat1.Position[1]] = Bat1.Avatar;
                }
                if(!Wolf1.IsDead())
                {
                    World.WorldMap[Wolf1.Position[0], Wolf1.Position[1]] = Wolf1.Avatar;
                }
                World.WorldMap[Hole1.Position[0], Hole1.Position[1]] = Hole1.Avatar;
                World.WorldMap[MainCharacter.Position[0], MainCharacter.Position[1]] = MainCharacter.Avatar;

                //Affiche la carte du monde.
                World.DrawMap(World.WorldMap);

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
                if(MainCharacter.Position[0] == Bat1.Position[0] && MainCharacter.Position[1] == Bat1.Position[1])
                {
                    World.Battle(MainCharacter, Bat1);
                    if(!MainCharacter.IsDead())
                    {
                        Console.WriteLine(Touches);
                        World.DrawMap(World.WorldMap);
                    }
                }
                if(MainCharacter.Position[0] == Wolf1.Position[0] && MainCharacter.Position[1] == Wolf1.Position[1])
                {
                    World.Battle(MainCharacter, Wolf1);
                    if (!MainCharacter.IsDead())
                    {
                        Console.WriteLine(Touches);
                        World.DrawMap(World.WorldMap);
                    }
                }

                if(Bat1.IsDead() && Wolf1.IsDead())
                {
                    Console.ReadKey();
                    Lost = true;
                }
                else if(MainCharacter.IsDead())
                {
                    Console.ReadKey();
                    Lost = true;
                }
                else
                {
                    //Gère tous les déplacements du jeu.
                    MainCharacter.Move(World);
                    if(!Bat1.IsDead())
                    {
                        Bat1.BatMove(World);
                    }
                    else
                    {
                        Bat1.HideInMap();
                    }
                    if(!Wolf1.IsDead())
                    {
                        Wolf1.WolfMove(World);
                    }
                    else
                    {
                        Wolf1.HideInMap();
                    }
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