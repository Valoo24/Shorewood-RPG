using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum ItemType { Potion, Cuir, Fouet, Bottes, Gilet, Chapeau }
    public class Item
    {
        public ItemType TypeOfItem;
        public int Quantity;
        public Item(ItemType TypeOfItem, int NewQuantity)
        {
            Quantity = NewQuantity;
            this.TypeOfItem = TypeOfItem;
        }

        public void ItemEffect(Hero Character, Monster Mob)
        {
            if(this.TypeOfItem == ItemType.Potion)
            {
                PotionEffect(Character);
            }
            if(this.TypeOfItem == ItemType.Cuir)
            {
                CuirEffect(Character, Mob);
            }


            this.Quantity -= 1;
            if(this.Quantity == 0)
            {
                Character.Inventaire.Remove(this);
            }
        }

        public void ItemEffect(Hero Character)
        {
            if (this.TypeOfItem == ItemType.Potion)
            {
                PotionEffect(Character);
            }
            if (this.TypeOfItem == ItemType.Cuir)
            {
                CuirEffect(Character);
            }


            this.Quantity -= 1;
            if (this.Quantity == 0)
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
            Console.WriteLine($"{Character.Name} utilise {this.TypeOfItem}. {Character.Name} Récupère {i} PV.");
        }

        public void CuirEffect(Hero Character, Monster Mob)
        {
            Mob.PV -= 1;
            Console.WriteLine($"{Character.Name} veut utiliser {this.TypeOfItem}...");
            Console.ReadKey();
            Console.WriteLine($"{Character.Name} ne trouve rien d'autre à faire que de lancer {this.TypeOfItem} à {Mob.Name}...");
            Console.WriteLine($"Ce n'est pas très utile, mais {Mob.Name} perds tout de même 1 PV");
        }

        public void CuirEffect(Hero Character)
        {
            Console.WriteLine($"{Character.Name} veut utiliser {this.TypeOfItem}... Mais cet objet est inutile ici.");
            Console.ReadKey();
        }
    }
}