using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class BeverageCollection
    {
        Beverage[] beverages;
        int beveragesLength;

        public BeverageCollection(int collectionSize)
        {
            beverages = new Beverage[collectionSize];
            beveragesLength = 0;
        }

        public void AddABeverage(string id, string desc, string pack, decimal price, bool active)
        {
            beverages[beveragesLength] = new Beverage(id, desc, pack, price, active);
            beveragesLength++;
        }

        public string[] PrintTheBeveragesInventory()
        {
            string[] allBeveragesString = new string[beveragesLength];
            int lineCounter = 0;

            if (beveragesLength > 0)
            {
                foreach (Beverage beverage in beverages)
                {
                    if (beverage != null)
                    {
                        allBeveragesString[lineCounter] = beverage.ToString();
                        lineCounter++;
                    }
                }
            }
            return allBeveragesString;
        }

        public string FindBeverageById(string id)
        {
            string foundBeverage = null;

            for (int i = 0; i < beverages.Length; i++)
            {
                if (beverages[i] != null)
                {
                    if (beverages[i].Id == id)
                    {
                        foundBeverage = beverages[i].ToString();
                    }
                }                                             
            }

            //foreach (Beverage beverage in beverages)
            //{
            //    if (beverage != null)
            //    {
            //        if (beverage.Id == id)
            //        {
            //            foundBeverage = beverage.ToString();
            //        }
            //    }
            //}

            return foundBeverage;
        }
        // this class will initialize the collection size (passed into constructor from Main), 
        // get the array for the entire collection, add new items, and search for a specific item.
        // You will want to add an "item already present" flag by making the search dual-purpose;
        // if it returns anything at all following the search by ID, there's already a beverage with that ID
        // and so the user cannot add one with the chosen ID.

        // search by ID first, THEN add the new item, ELSE error out. Burp from the UI.

    }
}
