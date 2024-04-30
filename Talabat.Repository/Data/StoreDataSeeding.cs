using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public class StoreDataSeeding
    {
        public static async Task AddDateSeeding(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
                var brandsObjects = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brandsObjects?.Count() > 0)
                {

                    foreach (var brand in brandsObjects)
                    {
                        context.Set<ProductBrand>().Add(brand);
                    }
                    context.SaveChanges();
                } 
            }
            if (!context.ProductCategories.Any())
            {
                var categoriesData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
                var categoriesObjects = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categoriesObjects?.Count() > 0)
                {

                    foreach (var category in categoriesObjects)
                    {
                        context.Set<ProductCategory>().Add(category);
                    }
                    context.SaveChanges();
                }
            }
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
                var productsObjects = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (productsObjects?.Count() > 0)
                {

                    foreach (var product in productsObjects)
                    {
                        context.Set<Product>().Add(product);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
