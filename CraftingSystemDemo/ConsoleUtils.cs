﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace CraftingSystemDemo
{
    class ConsoleUtils
    {

        public static void WaitForKeyPress()
        {
            Print("[Press any key to continue...]");
            ReadKey();
        }
        public static void WaitForKeyPress(bool ClearLineAfter)
        {
            Print("[Press any key to continue...]");
            ReadKey();
            // I like to clear the line after and then leave the space so my console isnt just filled with
            // waiting for key press messages.
            if (ClearLineAfter) 
            {
                GoBackOneLine();
                ClearCurrentConsoleLine();
                Print("");
            }
        }

        // i had methods like these in one of my projects last semester so i looked up how to do this again
        public static void GoBackOneLine()
        {
            
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            
        }
        public static void ClearCurrentConsoleLine()
        {
            //from stackoverflow https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        //establish delegates
        
        public delegate void PrintDelegate(string message);
        public static PrintDelegate Print = PrintConsole;

        public delegate void PrintSameLineDelegate(string message);
        public static PrintSameLineDelegate PrintSameLine = PrintSameLineConsole;


        /*
        public static void PrintConsole()
        {
            WriteLine();
        }
        */
        public static void PrintConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintSameLineConsole(string message)
        {
            Console.Write(message);
        }

        public static bool GetInputBool()
        {
            PrintSameLine("[Y/N]: ");

            
            string input = ReadKey(false).Key.ToString();
            Print("");

            if (input == "Y" || input == "y")
            {
                return true;
            }
            else if (input == "N" || input == "n")
            {
                return false;
            }
            else
            {
                Print("[Error, you must input \"Y\" or \"N\"]");
                return GetInputBool();
            }
        }
        

        public static int GetInputInt(int min, int max)
        {
            PrintSameLine("[" + min.ToString() + " - " + max.ToString() + "]: ");
            string input = ReadLine();
            int inputInt;
            try
            {
                inputInt = int.Parse(input);
                if (inputInt >= min && inputInt <= max)
                {
                    return inputInt;
                }
                else
                {
                    Print("[Error, you must input an integer between the Minimum and Maximum values]");
                    return GetInputInt(min, max);
                }
            }
            catch (Exception)
            {
                Print("[Error, you must input an integer between the Minimum and Maximum values]");
                return GetInputInt(min, max);
            }
            
        }
        

        public static string LoadTextFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static List<Item> LoadItemListFromFile(string path)
        {

            List<Item> items = new List<Item>();

            foreach (string s in File.ReadAllLines(path))
            {
                string[] subs = s.Split('~');
                items.Add(new Item(double.Parse(subs[0]), subs[1]));
            }

            return items;

        }

    }
}
