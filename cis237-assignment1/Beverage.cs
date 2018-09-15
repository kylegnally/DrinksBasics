﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class Beverage
    {
        public Beverage() { }

        public Beverage(string id, string desc, string pack, decimal price, bool active)
        {
            this.Id = id;
            this.Desc = desc;
            this.Pack = pack;
            this.Price = price;

            if (active)
            {
                this.Active = "true";
            }
            else this.Active = "false";
        }

        public override string ToString()
        {
            ItemAsString = Id + ", " + Desc + ", " + Pack + ", " + Price.ToString() + ", " + Active;
            return ItemAsString;
        }

        public string Id { get; set; }
        public string Desc { get; set; }
        public string Pack { get; set; }
        public decimal Price { get; set; }
        public string Active { get; set; }
        public string ItemAsString { get; set; }
    }
}