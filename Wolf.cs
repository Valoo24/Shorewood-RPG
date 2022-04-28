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
        public Wolf(Hero Hero)
        {
            Name = "Loup";
            EXP = 100;
            chance = 6;
            Force = 8;
            Endurance = 10;
            MaxPV = 50;
            PV = 50;
            SetPosition(Hero);
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
        #region Méthode
        public override void Loot(Hero Character)
        {
            bool isFound = false;
            int WhatFound = this.rand.Next(0, 2);
            switch(WhatFound)
            { 
                case 0:
                    foreach (Item item in Character.Inventaire)
                    {
                        if (item.TypeOfItem == ItemType.Potion)
                        {
                            item.Quantity += 1;
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Character.Inventaire.Add(new Item(ItemType.Potion, 1));
                    }
                    Console.WriteLine($"Super ! {Character.Name} trouve une potion sur le cadavre de {this.Name}");
                    break;
                case 1:
                    foreach (Item item in Character.Inventaire)
                    {
                        if (item.TypeOfItem == ItemType.Cuir)
                        {
                            item.Quantity += 1;
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Character.Inventaire.Add(new Item(ItemType.Cuir, 1));
                    }
                    Console.WriteLine($"Super ! {Character.Name} dépece le cadavre de {this.Name} et récupère 1 cuir.");
                    break;
            }
        }
        #endregion
    }
}