using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftingSystemDemo.ConsoleUtils;

namespace CraftingSystemDemo
{
    class Game
    {

        public void Run()
        {
            Title = "Crafting Demo";

            Player MyPlayer = new Player();
            PrintSameLine("What is your name? : ");

            MyPlayer.Name = ReadLine();

            Print("Welcome " + MyPlayer.Name);

            Print(LoadTextFromFile("../../data/welcome.txt"));
            Print(LoadTextFromFile("../../data/instructions.txt"));
            WaitForKeyPress(true);

            MyPlayer.Inventory = LoadItemListFromFile("../../data/startingInventory.txt");
            Print(ShowAllItemsInList(MyPlayer.Inventory, false));

            WaitForKeyPress(true);

            
            Recipe chamomileTea = new Recipe(
                new List<Item>()
                {
                    new Item(1, "Water"),
                    new Item(1, "Chamomile")

                },
                new Item(1, "Chamomile Tea")
                );
            

            
            Recipe sleepingPotion = new Recipe(
                new List<Item>()
                {
                    new Item(1, "Chamomile Tea"),
                    new Item(.5, "Ashwagandha"),
                    new Item(.5, "Dried Lavender"),
                    new Item(.5, "Lemon Balm")

                },
                new Item(1, "Sleeping Potion")
                );
            

            MyPlayer.Craft(chamomileTea);
            Print(ShowAllItemsInList(MyPlayer.Inventory, false));

            MyPlayer.Craft(sleepingPotion);
            Print(ShowAllItemsInList(MyPlayer.Inventory, false));

            Trader MyTrader = new Trader();
            //MyTrader.StartDialogue(MyPlayer);



            WaitForKeyPress(true);
        }
    }
}
