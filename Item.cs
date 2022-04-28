using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Item
    {
        public string Name;
        public int Quantity;

        public Item(string NewName, int NewQuantity)
        {
            Name = NewName;
            Quantity = NewQuantity;
        }

        public void ItemEffect(Hero Character, Monster Mob)
        {
            if(this.Name == "Potion")
            {
                PotionEffect(Character);
            }
            this.Quantity -= 1;
            if(this.Quantity == 0)
            {
                Character.Inventaire.Remove(this);
            }
        }

        public void PotionEffect(Hero Character)
        {
            int i;
            if (Character.MaxPV - Character.PV >= Character.MaxPV / 2)
            {
                i = Character.MaxPV / 2;
            }
            else
            {
                i = Character.MaxPV - Character.PV;
            }
            Character.PV += i;
            Console.WriteLine($"{Character.Name} utilise {this.Name}. {Character.Name} Récupère {i} PV.");
        }
    }
}
