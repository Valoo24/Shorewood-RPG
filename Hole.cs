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
            Avatar = "O";
            Damage = 10;
            SetTrapPosition(WorldMap);
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