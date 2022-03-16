using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; set; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());

            }

        }
        //This method is used as when we will run new containers for the MongoDB, the data will not be there, we need to seed it.
        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            List<Product> seedProducts = new List<Product>
            {
                new Product { id = "1", name = "iPhone", category = "Phones", description = "iPhone 13 Pro Max", price = 1300},
                new Product { id = "2", name = "Samsung OLED TV", category = "TV's", description = "OLED TV", price = 2650},
                new Product { id = "3", name = "Sony OLED TV", category = "TV's", description = "OLED TV with mini LED", price = 4500},
                new Product { id = "4", name = "Samsung Ultra 22", category = "Phones", description = "Samsung Galaxy Premium", price = 1200}

            };
            return seedProducts;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = Products.Find(p => true).ToList();
            return products;
            //            var messageCollection = database.GetCollection<MessageViewModel>("message")
            //var results = await Products.Find(x => true).ToListAsync();
            //return results;
        }
        //public static readonly List<Product> Products = new List<Product>
        //{
        //    new Product { Id = "1", Name = "iPhone", Category = "Phones", Description = "iPhone 13 Pro Max", Price = 1300},
        //    new Product { Id = "2", Name = "Samsung OLED TV", Category = "TV's", Description = "OLED TV", Price = 2650},
        //    new Product { Id = "3", Name = "Sony OLED TV", Category = "TV's", Description = "OLED TV with mini LED", Price = 4500},
        //    new Product { Id = "4", Name = "Samsung Ultra 22", Category = "Phones", Description = "Samsung Galaxy Premium", Price = 1200}

        //};

    }
}
