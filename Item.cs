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

        public void ItemEffect()
        {

        }
    }
}
