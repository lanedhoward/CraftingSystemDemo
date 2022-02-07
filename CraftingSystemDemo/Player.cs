using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingSystemDemo
{
    class Player : Person
    {

        public Player()
        {
            // initialize variables
            Money = 15;

            //starting player inventory
            Inventory.Add(new Item(2, "Toadstool"));
            Inventory.Add(new Item(10, "Feather", "From a bird, probably"));
            Inventory.Add(new Item(3, "Seaweed"));
        }
    }
}
