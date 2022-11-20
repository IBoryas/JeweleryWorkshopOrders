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
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<PriceList> Prices { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(OrderConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}