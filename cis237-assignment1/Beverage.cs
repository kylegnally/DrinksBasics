/* 
 * CIS237 Assignment 1 - Beverage List
 * 9/17/18
 * Kyle Nally
 * CIS237 T/Th 330pm * 
 */

namespace cis237_assignment1
{
    /// <summary>
    /// Class to handle one beverage item. Additional properties allow for future expanded search functionality.
    /// </summary>
    class Beverage
    {

        /// <summary>
        /// Default constructor. Unused. 
        /// </summary>
        public Beverage() { }

        /// <summary>
        /// Constructor for a single Beverage. Automatically sets the Active property to a string derived from the 
        /// state of the bool "active" param. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desc"></param>
        /// <param name="pack"></param>
        /// <param name="price"></param>
        /// <param name="active"></param>
        public Beverage(string id, string desc, string pack, decimal price, bool active)
        {
            this.Id = id;
            this.Desc = desc;
            this.Pack = pack;
            this.Price = price;

            if (active)
            {
                this.Active = "active";
            }
            else this.Active = "inactive";
        }

        /// <summary>
        /// ToString() override method used to return a single Beverage as a string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string beverageString = Id + ", " + Desc + ", " + Pack + ", " + "$" + Price.ToString() + ", " + Active;
            return beverageString;
        }

        /// <summary>
        /// Beverage Id property.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Beverage description.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Beverage pack size.
        /// </summary>
        public string Pack { get; set; }

        /// <summary>
        /// Beverage price (decimal data type).
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Beverage active status (string data type).
        /// </summary>
        public string Active { get; set; }

    }
}
