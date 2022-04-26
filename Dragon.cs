using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Dragon : Monster
    {
        public Dragon(Hero Hero)
        {
            Name = "Dragon";
            EXP = 200;
            chance = rand.Next(7, 9);
            for (int i = 0; i < chance / 2; i++)
            {
                Force += rand.Next(1, chance);
            }
            for (int i = 0; i < chance / 2; i++)
            {
                Endurance += rand.Next(1, chance);
            }
            PV = Endurance * chance;
            SetPosition(Hero);
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
    }
}
