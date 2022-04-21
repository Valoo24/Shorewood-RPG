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
        public Random rand = new Random();
        #endregion
        #region Méthodes
        public virtual void TrapEffect(Hero Character) { }
        #endregion
    }
}