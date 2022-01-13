using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.Api.Models;
using System;

namespace Shopping.Api.Persistence
{
    public class ProductDbContext
    {
        public IMongoCollection<Product> Products { get; init; }

        public ProductDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ProductCatalogDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["ProductCatalogDbSettings:DbName"]);
            Products = database.GetCollection<Product>(configuration["ProductCatalogDbSettings:CollectionName"]);

            SeedData(Products);
        }

        private static void SeedData(IMongoCollection<Product> productsCollection)
        {
            if (productsCollection.Find(x => true).Any())
                return;

            var rnd = new Random(57);

            for (int i = 1; i <= 20; i++)
                productsCollection.InsertOne(new Product
                {
                    Category = "Beverages",
                    Description = $"Product {i}'s description",
                    ImageFile = $"product-{i}.jpg",
                    Name = $"Product {i}",
                    Price = (decimal)rnd.NextDouble() * 100
                });
        }
    }
}
