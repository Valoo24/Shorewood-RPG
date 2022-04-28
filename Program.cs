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
            Map World = new Map(24, 55);
            Hero MainCharacter = new Hero(World);
            List<Trap> TrapList = new List<Trap>();
            Monster[] MonsterArray = { new Bat(MainCharacter), new Wolf(MainCharacter), new Dragon(MainCharacter) };

            TrapList.Add(new Hole(World));

            //Hole Hole1 = new Hole(World);

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
                    }
                }
                World.WorldMap[MainCharacter.Position[0], MainCharacter.Position[1]] = MainCharacter.Avatar;

                World.DrawMap();

                if (MainCharacter.CanFight)
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