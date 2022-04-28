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
        public string ASCII;
        #endregion
        #region constucteur
        public Monster()
        {
            Avatar = "‼";
        }
        #endregion
        #region Méthodes
        public void SetPosition(Hero Character)
        {
            do
            {
                this.Position[0] = this.rand.Next(1, 23);
                this.Position[1] = this.rand.Next(1, 54);
            } while(this.Position[0] == Character.Position[0] && this.Position[1] == Character.Position[1]);
        }
        public virtual void Loot(Hero Character) { }
        #endregion
    }
}