using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Dragon : Monster
    {
        public Dragon()
        {
            Name = "Dragon";
            EXP = 750;
            chance = 7;
            Force = 13;
            Endurance = 15;
            MaxPV = 100;
            PV = 100;
            #region ASCII Dragon
            ASCII = @"
              __                  __
             ( _)                ( _)
            / / \\              / /\_\_
           / /   \\            / / | \ \
          / /     \\          / /  |\ \ \
         /  /   ,  \ ,       / /   /|  \ \
        /  /    |\_ /|      / /   / \   \_\
       /  /  |\/ _ '_|\    / /   /   \    \\
      |  /   |/  0 \0\ \  / |    |    \    \\
      |    |\|      \_\_ /  /    |     \    \\
      |  | |/    \.\ o\o)  /      \     |    \\
      \    |     /\\`v-v  /        |    |     \\
       | \/    /_| \\_|  /         |    | \    \\
       | |    /__/_     /   _____  |    |  \    \\
       \|    [__]  \_/  |_________  \   |   \    ()
        /    [___] (    \         \  |\ |   |   //
       |    [___]                  |\| \|   /  |/
      /|    [____]                  \  |/\ / / ||
     (  \   [____ /     ) _\      \  \    \| | ||
      \  \  [_____|    / /     __/    \   / / //
      |   \ [_____/   / /        \    |   \/ //
      |   /  '----|   /=\____   _/    |   / //
   __ /  /        |  /   ___/  _/\    \  | ||
  (/-(/-\)       /   \  (/\/\)/  |    /  | /
                (/\/\)           /   /   //
                       _________/   /    /
                      \____________/    (";
            #endregion
        }
        public override void Loot(Hero Character)
        {
            Random r = new Random();
            bool IsFound = false;
            int WhatFound = r.Next(0, 3);
            switch(WhatFound)
            {
                case 0:
                    foreach (Item item in Character.Inventaire)
                    {
                        if (item.TypeOfItem == ItemType.Potion)
                        {
                            item.Quantity += 1;
                            IsFound = true;
                        }
                    }
                    if (!IsFound)
                    {
                        Character.Inventaire.Add(new Item(ItemType.Potion, 1));
                    }
                    Console.WriteLine($"Super ! {Character.Name} trouve une potion sur le cadavre de {this.Name}");
                    break;
                case 1:
                    foreach (Item item in Character.Inventaire)
                    {
                        if (item.TypeOfItem == ItemType.Potion)
                        {
                            item.Quantity += 2;
                            IsFound = true;
                        }
                    }
                    if (!IsFound)
                    {
                        Character.Inventaire.Add(new Item(ItemType.Potion, 2));
                    }
                    Console.WriteLine($"Super ! {Character.Name} trouve deux potions sur le cadavre de {this.Name}");
                    break;
                case 2:
                    foreach (Item item in Character.Inventaire)
                    {
                        if (item.TypeOfItem == ItemType.Potion)
                        {
                            item.Quantity += 3;
                            IsFound = true;
                        }
                    }
                    if (!IsFound)
                    {
                        Character.Inventaire.Add(new Item(ItemType.Potion, 3));
                    }
                    Console.WriteLine($"Super ! {Character.Name} trouve trois potions sur le cadavre de {this.Name}");
                    break;
            }
        }
    }
}