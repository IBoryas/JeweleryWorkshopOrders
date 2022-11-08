using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryWorkshopOrders.Dal.EntityConfigurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(x => x.StartDate)
                .HasColumnType("date");

            builder
                .Property(x => x.EndDate)
                .HasColumnType("date");

        }
    }
}
