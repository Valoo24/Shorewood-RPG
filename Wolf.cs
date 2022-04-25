using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Wolf : Monster
    {
        #region Constructeurs
        public Wolf()
        {
            Name = "Loup";
            EXP = 3;
            chance = 6;
            for (int i = 0; i < chance / 2; i++)
            {
                Force += rand.Next(1, chance);
            }
            for (int i = 0; i < chance / 2; i++)
            {
                Endurance += rand.Next(1, chance);
            }
            PV = Endurance + 2;
            AutoMove = 1;
            for (int i = 0; i < 2; i++)
            {
                this.Position[i] = rand.Next(15, 21);
            }
            #region ASCII Loup
            ASCII = @"
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@'~~~     ~~~`@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@'                     `@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@'                           `@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@'                               `@@@@@@@@@@@@@@@
@@@@@@@@@@@'                                   `@@@@@@@@@@@@@
@@@@@@@@@@'                                     `@@@@@@@@@@@@
@@@@@@@@@'                                       `@@@@@@@@@@@
@@@@@@@@@                                         @@@@@@@@@@@
@@@@@@@@'                      n,                 `@@@@@@@@@@
@@@@@@@@                     _/ | _                @@@@@@@@@@
@@@@@@@@                    /'  `'/                @@@@@@@@@@
@@@@@@@@a                 <~    .'                a@@@@@@@@@@
@@@@@@@@@                 .'    |                 @@@@@@@@@@@
@@@@@@@@@a              _/      |                a@@@@@@@@@@@
@@@@@@@@@@a           _/      `.`.              a@@@@@@@@@@@@
@@@@@@@@@@@a     ____/ '   \__ | |______       a@@@@@@@@@@@@@
@@@@@@@@@@@@@a__/___/      /__\ \ \     \___.a@@@@@@@@@@@@@@@
@@@@@@@@@@@@@/  (___.'\_______)\_|_|        \@@@@@@@@@@@@@@@@
@@@@@@@@@@@@|\________                       ~~~~~\@@@@@@@@@@";
            #endregion
        }
        #endregion
        #region Méthodes
        public void WolfMove(Map World)
        {
            if (this.Position[1] % 5 == 0)
            {
                this.AutoMove *= -1;
            }
            World.WorldMap[this.Position[0], this.Position[1]] = " ";
            this.Position[1] += this.AutoMove;
        }
        #endregion
    }
}
