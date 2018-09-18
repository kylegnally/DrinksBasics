/* 
 * CIS237 Assignment 1 - Beverage List
 * 9/17/18
 * Kyle Nally
 * CIS237 T/Th 330pm * 
 */

namespace cis237_assignment1
{
    /// <summary>
    /// Beverage collection class. Handles adding a beverage to the collection, printing the beverage inventory, and
    /// searching for a beverage by its ID. Future search functionality such as a FindBeverageByName() method should
    /// be implemented here (this functionality is already supported by the Beverage class).
    /// </summary>
    class BeverageCollection
    {
        Beverage[] beverages;
        int collectionPosition;

        /// <summary>
        /// Creates a new beverages array of type Beverage and of the size passed into it.
        /// Sets the initial position of the array counter to 0 (the beginning of the array).
        /// </summary>
        /// <param name="collectionSize"></param>
        public BeverageCollection(int collectionSize)
        {
            beverages = new Beverage[collectionSize];
            collectionPosition = 0;
        }

        /// <summary>
        /// Adds a beverage to the collection. Note that collectionPosition is always incremented by 1 after adding a new beverage
        /// to ensure the new beverage is always added at the end of the collection.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desc"></param>
        /// <param name="pack"></param>
        /// <param name="price"></param>
        /// <param name="active"></param>
        public void AddABeverage(string id, string desc, string pack, decimal price, bool active)
        {
            beverages[collectionPosition] = new Beverage(id, desc, pack, price, active);
            collectionPosition++;
        }
        
        /// <summary>
        /// Prints the entire inventory of beverages using the ToString() override method of the Beverage class.
        /// Returns the entire inventory as a string[].
        /// </summary>
        /// <returns>string[]</returns>
        public string[] PrintTheBeveragesInventory()
        {
            string[] allBeveragesString = new string[collectionPosition];

            for (int i = 0; i < beverages.Length; i++)
            {
                if (beverages[i] != null)
                {
                    allBeveragesString[i] = "\t\t\t\t" + beverages[i].ToString();
                }
            }
            
            return allBeveragesString;
        }

        /// <summary>
        /// Searches for a Beverage in the collection by its id. Returns the Beverage as a string.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public string FindBeverageById(string id)
        {
            string foundBeverage = null;

            // could be a foreach
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
            
            return foundBeverage;
        }

        // Additional future search functionality should go here
    }
}
