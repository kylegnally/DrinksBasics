/* 
 * CIS237 Assignment 1 - Beverage List
 * 9/17/18
 * Kyle Nally
 * CIS237 T/Th 330pm * 
 */

using System;

namespace cis237_assignment1
{
    /// <summary>
    /// Base class for the program. This is where Main() lives.
    /// </summary>
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
                        Console.WriteLine(aMenu.LoadListMessage());
                        bool loadedSuccessfully = csvProcessor.ImportCSV(pathToCSV, sodaStand);
                        if (loadedSuccessfully)
                        {
                            Console.Write(aMenu.LoadSuccess());
                            aMenu.Pause();
                        }
                        else
                        {           
                            // We don't want to try to reload the list again so we use the public boolean variable
                            // that is set from within the class. We use this in any situation where we don't want
                            // the user to do a thing until the list is loaded (add, search...).
                            if (csvProcessor.listIsLoaded)
                            {
                                Console.Write(aMenu.AlreadyLoaded());
                                aMenu.Pause();
                            }

                            else Console.Write(aMenu.LoadFailure());
                            aMenu.Pause();
                        }                        
                        
                        DisplayMenu();
                        break;
                    case "P":
                        // Print the list. Burp if the list isn't loaded yet.
                        aMenu.PrintListMessage();
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.NothingToPrint());
                            aMenu.Pause();
                        }
                        else
                        {
                            string[] allBeverages = sodaStand.PrintTheBeveragesInventory();
                            aMenu.PrintBeverageList(allBeverages);
                        }
                        aMenu.Pause();
                        DisplayMenu();

                        break;
                    case "S":
                        // Search the list. Burp if the list isn't loaded yet.
                        aMenu.SearchListMessage();
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.NothingToSearch());
                            aMenu.Pause();
                        }

                        else
                        {
                            Console.Write(aMenu.SearchBeverageList(sodaStand));
                        }                        
                        aMenu.Pause();
                        DisplayMenu();
                        break;
                    case "A":
                        // Add to the list. Burp if the list isn't loaded yet.
                        if (!csvProcessor.listIsLoaded)
                        {
                            Console.Write(aMenu.CannotAddUntilLoaded());
                            aMenu.Pause();
                        }
                        else
                        {
                            string[] beverageToAdd = aMenu.AddABeverage();
                            if (sodaStand.FindBeverageById(beverageToAdd[0]) == null)
                            {
                                sodaStand.AddABeverage(beverageToAdd[0], beverageToAdd[1], beverageToAdd[2], decimal.Parse(beverageToAdd[3]), bool.Parse(beverageToAdd[4]));
                                Console.Write(aMenu.BeverageAdded());
                                aMenu.Pause();
                            }
                            else
                            {
                                Console.Write(aMenu.BeverageExists());
                                aMenu.Pause();
                            }
                        }                        
                        aMenu.Pause();
                        DisplayMenu();
                        break;
                        // Quit the program. Quits regardless of whether the list is loaded. Never burps.
                    case "Q":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(aMenu.QuitProgramMessage());
                        aMenu.Pause();
                        Environment.Exit(0);
                        break;

                        // The default option is invoked for any choices not on the menu. This may be an invalid
                        // entry or a blank entry. In either case, error is shown in red and the menu is simply redrawn.
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        aMenu.InvalidOptionMessage();
                        aMenu.Pause();
                        DisplayMenu();
                        break;
                }
            }            
        }
    }
}

    