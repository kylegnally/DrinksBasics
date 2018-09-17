using System;

namespace cis237_assignment1
{
    class UserInterface
    {
        string menuString;

        public string DisplayMenu()
        {
            Console.ResetColor();
            menuString = "\n\n\n\n\n\t\t\t\tWelcome to BeverageBooth!\n\n" +
                "\t\t\t\tPlease select an option: \n\n" +
                "\t\t\t\t(L) Load the beverage list\n" +
                "\t\t\t\t(P) Print the beverage list\n" +
                "\t\t\t\t(S) Search the beverage list by beverage ID\n" +
                "\t\t\t\t(A) Add a beverage to the beverage list\n" +
                "\t\t\t\t(Q) Quit\n\n";
            return menuString;
        }

        public string AlreadyLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string alreadyLoadedError = "\n\t\t\t\tThe beverage list is already loaded.";
            return alreadyLoadedError;
        }

        public string LoadSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string listLoadSuccess = "\n\t\t\t\tBeverage list loaded successfully.";
            return listLoadSuccess;
        }

        public string LoadFailure()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string listLoadFailure = "\n\n\t\t\t\tBeverage list has failed to load.";
            return listLoadFailure;
        }

        public string NothingToPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string printError = "\n\t\t\t\tThe list is empty. There are no items to print.";
            printError += "\n\t\t\t\tDid you forget to load the beverage list first?";
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
            Console.Write("\n\t\t\t\tEnter the ID of the beverage you wish to search for: ");
            string id = Console.ReadLine();
            if (collection.FindBeverageById(id) != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foundBeverage = "\n\t\t\t\tItem found:" + collection.FindBeverageById(id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foundBeverage = "\n\t\t\t\tNo matching beverage item found.";
            }
            return foundBeverage;            
        }

        public string NothingToSearch()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string searchError = "\n\t\t\t\tThe list is empty. There are no items to search.";
            searchError += "\n\t\t\t\tDid you forget to load the beverage list first?";
            return searchError;
        }

        public string[] AddABeverage()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\n\n\t\t\t\tYou chose to (A)dd to the beverage list.");
            Console.Write("\n\t\t\t\tEnter the ID of the beverage you'd like to add: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string id = Console.ReadLine();            
            Console.ResetColor();
            Console.Write("\n\t\t\t\tEnter the description of the beverage you'd like to add: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string desc = Console.ReadLine();
            Console.ResetColor();
            Console.Write("\n\t\t\t\tEnter the pack size of the beverage you'd like to add: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string pack = Console.ReadLine();
            Console.ResetColor();
            Console.Write("\n\t\t\t\tEnter the price, without the $ sign (but including the decimal point) \n\t\t\t\tof the beverage you'd like to add: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string price = Console.ReadLine();
            Console.ResetColor();            
            Console.Write("\n\t\t\t\tIs this beverage (a)ctive or (i)nactive? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string active = Console.ReadLine().ToUpper();

            if (price.Contains("$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\tPlease do not include a dollar sign ('$') in the price. ");
                System.Threading.Thread.Sleep(3000);
                AddABeverage();
            }
            
            if (id == "" || desc == "" || pack == "" || price == "" || active == "")
            {
                if (active != "A")
                {
                    if (active != "I")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t\t\tIt seems some information is missing or incorrect. " +
                            "\n\t\t\t\tPlease reenter your choices and try again.");
                        System.Threading.Thread.Sleep(3000);
                        AddABeverage();
                    }
                }                
            }

            if (active == "A")
            {
                active = "true";
            }

            if (active == "I")
            {
                active = "false";
            }

            return new string[] { id, desc, pack, price, active };
        }

        //private bool GetNewBeverageActiveStatus()
        //{
        //    Console.ResetColor();
        //    string answer;
            
        //    if (answer != "A" || answer != "I")
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("\n\t\t\t\tYou must select (a)ctive or (i)nactive. Please try again.");
        //        GetNewBeverageActiveStatus();
        //    }
        //    if (answer == "A") return true;
        //    else return false;
        //}

        public string BeverageExists()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string alreadyExists = "\n\n\t\t\t\tThe beverage ID you have chosen already exists in the beverage list.";
            alreadyExists += "\n\t\t\t\tPlease try again and choose a different beverage ID.";
            return alreadyExists;
        }

        public string BeverageAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string beverageAdded = "\n\n\t\t\t\tNew beverage added.";
            return beverageAdded;
        }

        public string CannotAddUntilLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string addError = "\n\t\t\t\tThe list is empty. You cannot add to the list until it is loaded.";
            addError += "\n\t\t\t\tLoad the beverage list first, then try to add a new item again.";
            return addError;
        }
    }
}
