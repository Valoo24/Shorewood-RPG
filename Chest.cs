using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Chest : Trap
    {
        Item ItemInChest;
        public Chest(int PositionX, int PositionY, ItemType TypeOfContainingItem)
        {
            Name = "Coffre";
            ItemInChest = new Item(TypeOfContainingItem, 1);
            Position[0] = PositionX;
            Position[1] = PositionY;
        }

        public override void TrapEffect(Hero Character)
        {
            bool FoundInInventory = false;
            if (this.IsEffective)
            {
                Character.CanFight = false;
                Console.WriteLine($"{Character.Name} tombe sur {this.Name} ! {Character.Name} trouve {this.ItemInChest.Quantity} X {this.ItemInChest.TypeOfItem} !");
                foreach (Item item in Character.Inventaire)
                {
                    if (item.TypeOfItem == this.ItemInChest.TypeOfItem)
                    {
                        item.Quantity += ItemInChest.Quantity;
                        FoundInInventory = true;
                    }
                }
                if (!FoundInInventory)
                {
                    Character.Inventaire.Add(this.ItemInChest);
                }
                this.IsUneffective();
            }
        }
    }
}