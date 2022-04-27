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
        public void SetTrapPosition(Map WorldMap)
        {
            do
            {
                this.Position[0] = this.rand.Next(1, 23);
                this.Position[1] = this.rand.Next(1, 54);
            } while (WorldMap.WorldMap[this.Position[0], this.Position[1]] != " ");
        }
        #endregion
    }
}