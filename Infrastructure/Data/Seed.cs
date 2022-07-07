using Core.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            // Check if there is already data in the database.
            // Method won't run if there is already data.
            try
            {
                // ProductBrand table.
                if (!context.ProductBrands.Any())
                {
                    // Fetch json file data.
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    // Convert json file to entity.
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // Add the data to entity framework.
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    // Save to database.
                    await context.SaveChangesAsync();
                }

                // ProductType table.
                if (!context.ProductTypes.Any())
                {
                    // Fetch json file data.
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    // Convert json file to entity.
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    // Add the data to entity framework.
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    // Save to database.
                    await context.SaveChangesAsync();
                }

                // Product table.
                if (!context.Products.Any())
                {
                    // Fetch json file data.
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    // Convert json file to entity.
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    // Add the data to entity framework.
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    // Save to database.
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Seed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
