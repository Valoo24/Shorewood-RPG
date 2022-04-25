using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Bat : Monster
    {
        #region Constructeur
        public Bat()
        {
            Name = "Chauve-Souris";
            EXP = 2;
            chance = 4;
            for(int i = 0; i < chance / 2; i++)
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
                this.Position[i] = rand.Next(3, 6);
            }
            #region ASCII Chauve-souris
            ASCII = @"
#
 ##
 ###
  ####
   #####
   #######
    #######
    ########
    ########
    #########
    ##########
   ############
 ##############
################
 ################
   ##############
    ##############                                              ####
    ##############                                           #####
     ##############                                      #######
     ##############                                 ###########
     ###############                              #############
     ################                           ##############
    #################      #                  ################
    ##################     ##    #           #################
   ####################   ###   ##          #################
        ################  ########          #################
         ################  #######         ###################
           #######################       #####################
            #####################       ###################
              ############################################
               ###########################################
               ##########################################
                ########################################
                ########################################
                 ######################################
                 ######################################
                  ##########################      #####
                  ###  ###################           ##
                  ##    ###############
                  #     ##  ##########
                            ##    ###
                                  ###
                                  ##
                                  #


		
";
            #endregion
        }
        #endregion
        #region Méthodes
        public void BatMove(Map World)
        {
            if (this.Position[1] % 3 == 0)
            {
                this.AutoMove *= -1;
            }
            World.WorldMap[this.Position[0], this.Position[1]] = " ";
            this.Position[1] += this.AutoMove;
        }
        #endregion
    }
}