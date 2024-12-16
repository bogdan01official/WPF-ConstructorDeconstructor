using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Product
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, string description, int quantity)
        {
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
        }

        public void Deconstruct(out string name, out decimal price, out string description, out int quantity)
        {
            name = Name;
            price = Price;
            description = Description;
            quantity = Quantity;
        }

    }
}
