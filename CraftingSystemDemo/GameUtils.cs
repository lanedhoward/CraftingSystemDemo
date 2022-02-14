using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingSystemDemo
{
    class GameUtils
    {
        public static string ShowAllItemsInList(List<Item> items, bool showPrice)
        {
            string output = "";
            int index = 1;
            // since this is player facing, it should be 1 indexed. 
            //keep this in mind whenever picking something out of the list

            foreach (Item item in items)
            {

                // every item will have a quantity and a name.
                output += "  [" + index + "]" + "   " + item.Quantity + " " + item.Name;

                //some will have a description, so if they have one, show it
                if (item.Description != "" && item.Description != null)
                {
                    output += ": " + item.Description;
                }

                //showPrice is for shops and such
                if (showPrice)
                {
                    output += " ---- " + item.Price.ToString("C");
                }

                //end with a new line
                output += "\n";

                //increment index
                index += 1;
            }

            return output;
        }

        public static (bool, Item) SearchInventoryByName(string name, List<Item> inventory)
        {
            Item resultItem = new Item(1,"Garbage");
            bool success = false;
            foreach (Item i in inventory)
            {
                if (i.Name == name)
                {
                    resultItem = i;
                    success = true;
                    break;
                }
            }
            return (success, resultItem);
        }

    }
}
