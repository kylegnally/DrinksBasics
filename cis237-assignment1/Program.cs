/* 
 * CIS237 Assignment 1 - Beverage List
 * 9/17/18
 * Kyle Nally
 * CIS237 T/Th 330pm * 
 */

using System;

namespace cis237_assignment1
{
    class Program
    {
        /// <summary>
        /// Main program entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const int sodaStandSize = 4000;
            string pathToCSV = "../../../datafiles/beverage_list.csv";
            string menuChoice = null;

            UserInterface aMenu = new UserInterface();
            BeverageCollection sodaStand = new BeverageCollection(sodaStandSize);
            CSVProcessor csvProcessor = new CSVProcessor();

            DisplayMenu();

            /// Displays the menu and calls HandleInput to deal with the user's response stored in the variable menuChoice.
            void DisplayMenu()
            {
                Console.Clear();
                Console.Write(aMenu.DisplayMenu());
                Console.Write("\n\n\t\t\t\t");
                menuChoice = Console.ReadLine();
                HandleInput(menuChoice);
            }

            /// Handles the user's input via a switch. Each menu function is encapsulated within each case. 
            /// The work done on the user's choice is done in other classes; the output is handled by the
            /// UserInterface class.
            /// 
             
            void HandleInput(string userSelection)
            {
                userSelection = userSelection.ToUpper();
                switch (userSelection)
                {
                    // Loads the beverage list. Note that this is the only location we call ImportCSV() from.
                    case "L":
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (L)oad the beverage list.");                        
                        bool loadedSuccessfully = csvProcessor.ImportCSV(pathToCSV, sodaStand);
                        if (loadedSuccessfully)
                        {
                            Console.Write(aMenu.LoadSuccess());
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {           
                            // We don't want to try to reload the list again so we use the public boolean variable
                            // that is set from within the class. We use this in any situation where we don't want
                            // the user to do a thing until the list is loaded (add, search...).
                            if (csvProcessor.listIsLoaded)
                            {
                                Console.Write(aMenu.AlreadyLoaded());
                                System.Threading.Thread.Sleep(1500);
                            }

                            else Console.Write(aMenu.LoadFailure());
                            System.Threading.Thread.Sleep(1500);
                        }                        
                        
                        DisplayMenu();
                        break;
                    case "P":
                        // Print the list. Burp if the list isn't loaded yet.
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (P)rint the beverage list.\n");
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.NothingToPrint());
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            string[] allBeverages = sodaStand.PrintTheBeveragesInventory();
                            aMenu.PrintBeverageList(allBeverages);
                        }
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();

                        break;
                    case "S":
                        // Search the list. Burp if the list isn't loaded yet.
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (S)earch the beverage list.");
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.NothingToSearch());
                            System.Threading.Thread.Sleep(1500);
                        }

                        else
                        {
                            Console.Write(aMenu.SearchBeverageList(sodaStand));
                        }                        
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();
                        break;
                    case "A":
                        // Add to the list. Burp if the list isn't loaded yet.
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.CannotAddUntilLoaded());
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            string[] beverageToAdd = aMenu.AddABeverage();
                            if (sodaStand.FindBeverageById(beverageToAdd[0]) == null)
                            {
                                sodaStand.AddABeverage(beverageToAdd[0], beverageToAdd[1], beverageToAdd[2], decimal.Parse(beverageToAdd[3]), bool.Parse(beverageToAdd[4]));
                                Console.Write(aMenu.BeverageAdded());
                                System.Threading.Thread.Sleep(1500);
                            }
                            else
                            {
                                Console.Write(aMenu.BeverageExists());
                                System.Threading.Thread.Sleep(1500);
                            }
                        }                        
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();
                        break;
                        // Quit the program. Quits regardless of whether the list is loaded. Never burps.
                    case "Q":
                        Console.WriteLine("\n\n\t\t\t\tExiting program.");
                        System.Threading.Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;

                        // The default option is invoked for any choices not on the menu. This may be an invalid
                        // entry or a blank entry. In either case, error is shown in red and the menu is simply redrawn.
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\t\t\t\tInvalid option. Please select a valid option from the menu.");
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();
                        Environment.Exit(0);
                        break;
                }
            }            
        }
    }
}

    