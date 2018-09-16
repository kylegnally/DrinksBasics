using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class UserInterface
    {
        string menuString;

        public string DisplayMenu()
        {
            Console.ResetColor();
            menuString = "\n\n\n\n\n\t\t\t\t\t\tWelcome to BeverageBooth!\n\n" +
                "\t\t\t\t\t\tPlease select an option: \n\n" +
                "\t\t\t\t\t\t(L) Load the beverage list\n" +
                "\t\t\t\t\t\t(P) Print the beverage list\n" +
                "\t\t\t\t\t\t(S) Search the beverage list by beverage ID\n" +
                "\t\t\t\t\t\t(A) Add a beverage to the beverage list\n" +
                "\t\t\t\t\t\t(Q) Quit\n\n";
            return menuString;
        }

        public string AlreadyLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string alreadyLoadedError = "\n\t\t\t\t\t\tThe beverage list is already loaded.";
            return alreadyLoadedError;
        }

        public string LoadSuccess()
        {
            string listLoadSuccess = "\n\t\t\t\t\t\tBeverage list loaded successfully.";
            return listLoadSuccess;
        }

        public string LoadFailure()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string listLoadFailure = "\n\n\t\t\t\t\t\tBeverage list has failed to load.";
            return listLoadFailure;
        }

        public string NothingToPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string printError = "\n\t\t\t\t\t\tThe list is empty. There are no items to print.";
            printError += "\n\t\t\t\t\t\tDid you forget to load the beverage list first?";
            return printError;
        }

        public void PrintBeverageList(string[] allBeverages)
        {
            for (int i = 0; i < allBeverages.Length; i++)
            {
                if (allBeverages[i] != null)
                {
                    Console.WriteLine(allBeverages[i]);
                }
            }
        }

        public string SearchBeverageList(BeverageCollection collection)
        {
            string foundBeverage = "";
            Console.Write("\n\t\t\t\t\t\tEnter the ID of the beverage you wish to search for: ");
            string id = Console.ReadLine();
            if (collection.FindBeverageById(id) != null)
            {
                foundBeverage = collection.FindBeverageById(id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foundBeverage = "\n\t\t\t\t\t\tNo matching beverage item found.";
            }
            return foundBeverage;            
        }

        public string NothingToSearch()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string searchError = "\n\t\t\t\t\t\tThe list is empty. There are no items to search.";
            searchError += "\n\t\t\t\t\t\tDid you forget to load the beverage list first?";
            return searchError;
        }
    }
}
