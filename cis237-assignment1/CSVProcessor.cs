using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class CSVProcessor
    {
        private StreamReader streamReader = null;

        public bool ImportCSV(string pathToCSV, BeverageCollection[] beverages)
        {
            try
            {
                string csvLine;
                streamReader = new StreamReader(pathToCSV);
                int counter = 0;
                while ((csvLine = streamReader.ReadLine()) != null)
                {
                    this.processCSVLine(csvLine, beverages, counter++);
                }
                return true;
            }

            catch (Exception e)
            {
                // output the exception
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
                // return false because we failed
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

        private void processCSVLine(string line, Beverage[] beverage, int index)
        {
            // declare am array of parts that will contain the results of
            // splitting the string
            string[] parts = line.Split(',');

            // assign each part to a variable
            string id = parts[0];
            string desc = parts[1];
            string pack = parts[2];
            //string price = parts[3];
            decimal price = decimal.Parse(parts[3]);

            bool active = bool.Parse(parts[4]);

            // write the method for this into the beverage collection class. This is what
            // will initially populate the collection with the beverages when the list is loaded
            // for the first time
            //beverageCollection.AddNewItem(id, desc, pack, price, active);
        }
    }
}
