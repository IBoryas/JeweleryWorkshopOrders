using JewelryWorkshopOrders.Dal.EntityConfigurations;
using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;

namespace JewelryWorkshopOrders.Dal
{
    public class JewelryWorkshopOrdersDbContext: DbContext
    {
        public JewelryWorkshopOrdersDbContext(DbContextOptions<JewelryWorkshopOrdersDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<PriceList> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            var assembly = typeof(OrderConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}