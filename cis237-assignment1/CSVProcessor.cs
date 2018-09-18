/* 
 * CIS237 Assignment 1 - Beverage List
 * 9/17/18
 * Kyle Nally
 * CIS237 T/Th 330pm * 
 */

using System;
using System.IO;

namespace cis237_assignment1
{
    /// <summary>
    /// Class to handle processing a CSV file. 
    /// </summary>
    class CSVProcessor
    {

        /// <summary>
        /// This public bool is used in Main() as a flag to check whether the list is loaded and forbid the user
        /// from taking certain actions until the flag is true. 
        /// </summary>
        public bool listIsLoaded = false;

        public CSVProcessor()
        {
            this.listIsLoaded = false;
        }

        /// <summary>
        /// Public method to import the CSV. Checks to see if the list is NOT loaded; if it isn't, it
        /// sends the CSV one line at a time to the ImportCSV() method. If the CSV is already loaded
        /// this method returns false.
        /// </summary>
        /// <param name="pathToCSV"></param>
        /// <param name="sodaStand"></param>
        /// <returns>bool</returns>
        public bool ImportCSV(string pathToCSV, BeverageCollection sodaStand)
        {
            StreamReader streamReader = null;

            if (!listIsLoaded)
            {
                try
                {
                    string csvLine;
                    streamReader = new StreamReader(pathToCSV);
                    int counter = 0;
                    while ((csvLine = streamReader.ReadLine()) != null)
                    {
                        this.processCSVLine(csvLine, sodaStand, counter++);
                    }
                    listIsLoaded = true;
                    return true;
                }

                catch (Exception e)
                {
                    // output the exception
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                    Console.WriteLine(e.StackTrace);
                    // return false if things went wrong
                    return false;
                }

                finally
                {
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                }
            }
            else return false;
        }

        /// <summary>
        /// Processes one line of the CSV file. Splits the line by delimiters (',') and stores each part
        /// as a member of a string array. Automatically parses price to decimal and active/inactive to bool.
        /// Lastly, calls the collection's AddABeverage() method and adds the beverage to the collection.  
        /// </summary>
        /// <param name="line"></param>
        /// <param name="sodaStand"></param>
        /// <param name="index"></param>
        private void processCSVLine(string line, BeverageCollection sodaStand, int index)
        {
            // declare an array of parts that will contain the results of
            // splitting the string
            string[] parts = line.Split(',');

            // assign each part to a variable
            string id = parts[0];
            string desc = parts[1];
            string pack = parts[2];
            //string price = parts[3];
            decimal price = decimal.Parse(parts[3]);

            bool active = bool.Parse(parts[4]);

            // populate the list with one item
            sodaStand.AddABeverage(id, desc, pack, price, active);
        }
    }
}
