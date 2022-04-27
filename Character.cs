using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Character
    {
        #region Attributs
        public string Name;
        public string Avatar;
        public int[] Position = new int[2];
        public int chance;
        public int MaxPV;
        public int PV;
        public int Force;
        public int Endurance;
        public int EXP;
        public int Level;
        public Random rand = new Random();
        #endregion
        #region Méthodes
        public bool IsDead()
        {
            if (this.PV > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public int throwDice(int NumberOfThrow)
        {
            int result = 0;

            for (int i = 0; i < NumberOfThrow; i++)
            {
                result += this.rand.Next(1, this.chance + 1);
            }

            return result;
        }
        public void Attack(Character Opponent)
        {
            Console.WriteLine($"{this.Name} se lance à l'assaut !");
            if(this.throwDice(this.chance) > Opponent.Endurance)
            {
                Opponent.PV -= this.Force;
                Console.WriteLine($"{Opponent.Name} est touché et perds {this.Force} PV!");
            }
            else
            {
                Console.WriteLine($"L'attaque de {this.Name} a échoué.");
            }
        }
        #endregion
    }
}