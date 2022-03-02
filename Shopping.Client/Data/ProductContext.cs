using Shopping.Client.Models;
using System.Collections.Generic;

namespace Shopping.Client.Data
{
    public static class ProductContext
    {

        public static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = "1", Name = "iPhone", Category = "Phones", Description = "iPhone 13 Pro Max", Price = 1300},
            new Product { Id = "2", Name = "Samsung OLED TV", Category = "TV's", Description = "OLED TV", Price = 2650},
            new Product { Id = "3", Name = "Sony OLED TV", Category = "TV's", Description = "OLED TV with mini LED", Price = 4500},
            new Product { Id = "4", Name = "Samsung Ultra 22", Category = "Phones", Description = "Samsung Galaxy Premium", Price = 1200}

        };

    }
}
