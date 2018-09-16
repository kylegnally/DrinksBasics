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
        bool validChoice = true;

        public string DisplayMenu()
        {
            menuString = "\n\n\n\n\n\t\t\t\t\t\tWelcome to WineShop!\n\n" +
                "\t\t\t\t\t\tPlease select an option: \n\n\n\n" +
                "\t\t\t\t\t\t(L) Load the WineList\n" +
                "\t\t\t\t\t\t(P) Print the WineList\n" +
                "\t\t\t\t\t\t(S) Search the WineList\n" +
                "\t\t\t\t\t\t(A) Add a wine to the WineList\n" +
                "\t\t\t\t\t\t(Q) Quit\n\n";
            return menuString;
        }

        public string AlreadyLoaded()
        {
            string alreadyLoadedError = "\t\t\t\t\t\tThe beverage list is already loaded.";
            return alreadyLoadedError;
        }

        public string LoadSuccess()
        {
            string listLoadSuccess = "\t\t\t\t\t\tBeverage list loaded successfully.";
            return listLoadSuccess;
        }

        public string LoadFailure()
        {
            string listLoadFailure = "\n\n\t\t\t\t\t\tBeverage list has failed to load.";
            return listLoadFailure;
        }

        public string NothingToPrint()
        {
            string printError = "\t\t\t\t\t\tThe list is empty. There are no items to print.";
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
    }
}
