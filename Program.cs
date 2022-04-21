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
            Map World = new Map();
            Hole Hole1 = new Hole();

            World.WorldMap = World.InitializeMap(24, 55);

            MainCharacter.Position[0] = World.WorldMap.GetLength(0)/2;
            MainCharacter.Position[1] = World.WorldMap.GetLength(1)/2;

            Console.WriteLine("Veuillez saisir le nom de votre héros.");
            MainCharacter.Name = Console.ReadLine();
            //MainCharacter.Race = Hero.SetRace(MainCharacter);
            MainCharacter.Avatar = Hero.SetAvatar(MainCharacter);

            while (!Lost)
            {
                //Hero.ShowStats(MainCharacter);
                Console.WriteLine(Touches);

                //Place tous les éléments sur la carte du monde.
                if(!Bat1.IsDead())
                {
                    World.WorldMap[Bat1.Position[0], Bat1.Position[1]] = Bat1.Avatar;
                }
                World.WorldMap[Hole1.Position[0], Hole1.Position[1]] = Hole1.Avatar;
                World.WorldMap[MainCharacter.Position[0], MainCharacter.Position[1]] = MainCharacter.Avatar;

                //Affiche la carte du monde.
                World.DrawMap(World.WorldMap);

                //Gère les interactions entre le héros et le pièges / ennemis.
                if (MainCharacter.Position[0] == Hole1.Position[0] && MainCharacter.Position[1] == Hole1.Position[1])
                {
                    Hole1.TrapEffect(MainCharacter);
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

                if(MainCharacter.IsDead())
                {
                    Lost = true;
                }
                else
                {
                    //Gère tous les déplacements du jeu.
                    Hero.Move(MainCharacter, World);
                    if(!Bat1.IsDead())
                    {
                        Bat1.BatMove(World);
                    }
                    else
                    {
                        Bat1.HideInMap();
                    }
                }

                Console.Clear();
            }
            Console.WriteLine("PERDU !");
            Console.ReadKey();
        }
    }
}