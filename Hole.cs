using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Hole : Trap
    {
        #region Constructeur
        public Hole()
        {
            Avatar = "O";
            Damage = 10;
            for (int i = 0; i < 2; i++)
            {
                this.Position[i] = rand.Next(9, 11);
            }
        }
        #endregion
        #region Méthodes
        public override void TrapEffect(Hero Character)
        {
            Character.PV -= this.Damage;
        }
        #endregion
    }
}