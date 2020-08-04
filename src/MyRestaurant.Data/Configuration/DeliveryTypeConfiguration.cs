using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class DeliveryTypeConfiguration : IEntityTypeConfiguration<DeliveryType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryType> builder)
        {
            builder.ToTable("DeliveryType", "dbo").HasMany(m => m.Orders);
            builder.HasMany(m => m.MenuItems);
        }
    }
}
