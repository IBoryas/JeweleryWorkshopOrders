using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Seed
{
    public class ProductSeed
    {
        public static async Task Seed(JewelryWorkshopOrdersDbContext context)
        {
            if(!context.Product.Any())
            {
                var chain = new ProductCategory()
                {
                    CategoryName = "Chain"
                };

                var ring = new ProductCategory()
                {
                    CategoryName = "Ring"
                };

                var pendant = new ProductCategory()
                {
                    CategoryName = "Pendant"
                };

                context.ProductCategory.AddRange(chain,ring,pendant);

                var bismark = new Product()
                {
                    Category = chain,
                    ProductName = "Bismark"
                };

                var anchor = new Product()
                {
                    Category = chain,
                    ProductName = "Anchor"
                };

                var camomile = new Product()
                {
                    Category = chain,
                    ProductName = "Camomile"
                };

                context.Product.AddRange(bismark,anchor,camomile);

                var wedding = new Product()
                {
                    Category = ring,
                    ProductName = "Wedding"
                };

                var signet = new Product()
                {
                    Category = ring,
                    ProductName = "Signet"
                };

                var gems = new Product()
                {
                    Category = ring,
                    ProductName = "With Gems"
                };

                context.Product.AddRange(wedding, signet, gems);

                var pendantGems = new Product()
                {
                    Category = pendant,
                    ProductName = "With Gems"
                };

                var pendantNoGems = new Product()
                {
                    Category = pendant,
                    ProductName = "Without Gems"
                };

                context.Product.AddRange(pendantGems, pendantNoGems);

                await context.SaveChangesAsync();
            }
        }
    }
}
