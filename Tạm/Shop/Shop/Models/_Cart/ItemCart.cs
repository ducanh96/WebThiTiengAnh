using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models._Cart
{
    public class ItemCart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double GetTotal()
        {
            return Quantity * Price;
        }
    }
}