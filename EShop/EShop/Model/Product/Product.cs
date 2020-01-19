using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Product
{
    public class Product
    {
        public Product(string name, string description, double price, string country, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Country = country;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public int CategoryId { get; set; }
    }
}
