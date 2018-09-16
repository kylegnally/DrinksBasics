using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sodaStandSize = 4000;
            string pathToCSV = "../../../datafiles/beverage_list.csv";

            UserInterface aMenu = new UserInterface();
            BeverageCollection sodaStand = new BeverageCollection(4000);
            CSVProcessor csvProcessor = new CSVProcessor();

            csvProcessor.ImportCSV(pathToCSV, sodaStand);
            

            // testing only
            string[] allBeverages = sodaStand.PrintTheBeveragesInventory();
            foreach (string beverageItem in allBeverages)
            {
                Console.WriteLine(beverageItem);
            }
            Console.WriteLine("Test completed.");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Enter a beverage ID: ");
            string beverageID = Console.ReadLine();
            Console.WriteLine(sodaStand.FindBeverageById(beverageID));
            Console.WriteLine("Test completed.");
            System.Threading.Thread.Sleep(3000);
            // end testing

        }
    }
}

    