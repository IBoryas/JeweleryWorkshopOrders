using JeweleryWorkshopOrders.API;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using JewelryWorkshopOrders.Dal;
using Microsoft.EntityFrameworkCore;
using JewelryWorkshopOrders.Dal.Seed;

namespace JewelryWorkshopOrders.API.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<JewelryWorkshopOrdersDbContext>();
                context.Database.Migrate();

                await EmployeeSeed.Seed(context);
                await MaterialSeed.Seed(context);
                await ProductSeed.Seed(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}
