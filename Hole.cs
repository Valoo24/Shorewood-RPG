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
        public Hole(int PositionX, int PositionY)
        {
            Name = "trou";
            Position[0] = PositionX;
            Position[1] = PositionY;
        }
        #endregion
        #region Méthodes
        public override void TrapEffect(Hero Character)
        {
            if (this.IsEffective)
            {
                Character.CanFight = false;
                Console.WriteLine($"{Character.Name} tombe dans un {this.Name}. {Character.Name} perds {(int)(Character.MaxPV * 0.25f)}PV.");
                Character.PV -= (int)(Character.MaxPV * 0.25f);
                if (Character.PV < 0)
                {
                    Character.PV = 0;
                }
                this.IsUneffective();
            }
        }
        #endregion
    }
}