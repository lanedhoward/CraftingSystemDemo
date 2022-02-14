using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftingSystemDemo.ConsoleUtils;
using static CraftingSystemDemo.GameUtils;

namespace CraftingSystemDemo
{
    class Trader : Person
    {
        public Trader()
        {
            // initialize variables
            Name = "Ol' Shopkeep Steve";
            Money = 100;

            //initialize inventory
            RedDye redDye = new RedDye(5) { Price = 1 };
            BlueDye blueDye = new BlueDye(5) { Price = 1 } ;

            
            Inventory.Add(redDye);
            Inventory.Add(blueDye);
        }

        public void StartDialogue(Player player)
        {
            Say("Well hey there, stranger! Can I interest you in some wares?",false);
            Say("Here's what I've got.",false);
            Print("");
            
            Print(ShowAllItemsInList(Inventory,true));

            Print($"[You have {player.Money.ToString("C")}]");

            Say("Would you like to make a purchase? ");
            bool inputBool = GetInputBool();
            if (inputBool)
            {
                Say("What would you like to purchase?");
                int inputInt = GetInputInt(1, Inventory.Count);

                Item i = Inventory[inputInt-1];

                if (i.Price <= player.Money)
                {
                    //buy the item
                    player.Money -= i.Price;

                    var searchResults = SearchInventoryByName(i.Name, player.Inventory);

                    if (searchResults.Item1) //if successfully found item in players inventory
                    {
                        if (i.Quantity == 1)
                        {
                            // only one item, just move it
                            Inventory.Remove(i);
                        }
                        else
                        {
                            // but what if the item is in a stack??
                            i.Quantity -= 1;
                        }
                        searchResults.Item2.Quantity += 1;
                    }
                    else
                    {
                        if (i.Quantity == 1)
                        {
                            // only one item, just move it
                            Inventory.Remove(i);
                            player.Inventory.Add(i);
                        }
                        else
                        {
                            // but what if the item is in a stack??
                            Item newItem = Item.ItemClone(i);
                            newItem.Quantity = 1;
                            player.Inventory.Add(newItem);
                            i.Quantity -= 1;
                        }
                    }
                    // but what if the player already has a stack of the item??
                    

                    Say("All yours, pal!");
                    Say("Pleasure doin' business!", true);
                }
                else
                {
                    Say("Sorry, pal, your wallet's lookin' a bit too light for that one.",true);
                }

            }
            else
            {
                Say("Alrighty then; maybe next time I'll get your business");
            }


            WaitForKeyPress(true);
        }
    }
}
