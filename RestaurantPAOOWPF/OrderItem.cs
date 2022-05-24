using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPAOOWPF
{
    internal class OrderItem
    {
        public string name { get; set; }
        public int amount { get; set; }
        public float price { get; set; }

        public OrderItem(string name, int amount, float price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;
        }

        public override string ToString() 
        { 
            return name + " | Amount: " + amount + " | Price: " + price;
        }

        public string ToStringReceipt()
        {
            return name + "," + amount + "," + price;
        }
    }
}
