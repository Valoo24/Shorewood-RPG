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
        public Hole(Map WorldMap)
        {
            Name = "trou";
            Damage = 10;
            SetTrapPosition(WorldMap);
        }
        #endregion
        #region Méthodes
        public override void TrapEffect(Hero Character)
        {
            if (this.IsEffective)
            {
                Character.CanFight = false;
                Console.WriteLine($"{Character.Name} tombe dans un {this.Name}. {Character.Name} perds {this.Damage}PV.");
                Character.PV -= this.Damage;
                if (Character.PV < 0)
                {
                    Character.PV = 0;
                }
                this.Avatar = " ";
                this.IsEffective = false;
            }
        }
        #endregion
    }
}