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
        public Bat(Hero Hero)
        {
            Name = "Chauve-Souris";
            EXP = 50;
            chance = 5;
            Force = 6;
            Endurance = 8;
            MaxPV = 25;
            PV = 25;
            SetPosition(Hero);
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
        public override void Loot(Hero Character)
        {
            bool isFound = false;
            if(this.rand.Next(0, 4) > 2)
            {
                foreach(Item item in Character.Inventaire)
                {
                    if(item.Name == "Potion")
                    {
                        item.Quantity += 1;
                        isFound = true;
                    }
                }
                if(!isFound)
                {
                    Character.Inventaire.Add(new Item("Potion", 1));
                }
                Console.WriteLine($"Super ! {Character.Name} trouve une potion sur le cadavre de {this.Name}");
            }
        }
        #endregion
    }
}