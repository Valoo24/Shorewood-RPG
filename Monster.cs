using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Monster : Character
    {
        #region Attributs
        public int AutoMove;
        public int EXP;
        public string ASCII;
        #endregion
        #region constucteur
        public Monster()
        {
            Avatar = "‼";
        }
        #endregion
        #region Méthodes
        public void HideInMap()
        {
            this.Avatar = "";
            this.Position[0] = 0;
            this.Position[1] = 0;
        }
        #endregion
    }
}