using System;

namespace cis237_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sodaStandSize = 4000;
            string pathToCSV = "../../../datafiles/beverage_list_trunc.csv";
            string menuChoice = null;

            UserInterface aMenu = new UserInterface();
            BeverageCollection sodaStand = new BeverageCollection(sodaStandSize);
            CSVProcessor csvProcessor = new CSVProcessor();

            //csvProcessor.ImportCSV(pathToCSV, sodaStand);
            DisplayMenu();

            void DisplayMenu()
            {
                System.Console.Clear();
                Console.Write(aMenu.DisplayMenu());
                Console.Write("\n\n\t\t\t\t");
                menuChoice = Console.ReadLine();
                HandleInput(menuChoice);
            }

            void HandleInput(string userSelection)
            {
                //bool validChoice = true;
                userSelection = userSelection.ToUpper();
                switch (userSelection)
                {
                    case "L":
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (L)oad the beverage list.");                        
                        bool loadedSuccessfully = csvProcessor.ImportCSV(pathToCSV, sodaStand);
                        if (loadedSuccessfully)
                        {
                            Console.Write(aMenu.LoadSuccess());
                        }
                        else
                        {                            
                            if (csvProcessor.listIsLoaded == true)
                            {
                                Console.Write(aMenu.AlreadyLoaded());
                            }

                            else Console.Write(aMenu.LoadFailure());
                        }                        
                        
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();
                        break;
                    case "P":
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (P)rint the beverage list.");
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
                        Console.WriteLine("\n\n\t\t\t\tYou chose to (A)dd to the beverage list.");
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
                            }
                            else
                            {
                                aMenu.BeverageExists();
                            }
                        }                        
                        System.Threading.Thread.Sleep(1500);
                        DisplayMenu();
                        break;
                    case "Q":
                        Console.WriteLine("\n\n\t\t\t\tExiting program.");
                        System.Threading.Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
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

    