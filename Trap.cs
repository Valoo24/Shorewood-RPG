using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Trap
    {
        #region Atributs
        public int[] Position = new int[2];
        public string Avatar;
        public string Name;
        public int Damage;
        public bool IsEffective;
        public Random rand;
        #endregion
        #region Constructeur
        public Trap()
        {
            Avatar = "*";
            IsEffective = true;
        }
        #endregion
        #region Méthodes
        public virtual void TrapEffect(Hero Character){}
        public void IsUneffective()
        {
            this.Avatar = " ";
            this.IsEffective = false;
        }
        #endregion
    }
}