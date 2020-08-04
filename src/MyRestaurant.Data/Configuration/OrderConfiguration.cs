using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "dbo")
                .HasOne(m => m.DeliveryType);

            builder.HasOne(m => m.PaidMethod).WithMany(m => m.Orders).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.Restaurant).WithMany(m => m.Orders).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.User).WithMany(m => m.Orders).OnDelete(DeleteBehavior.NoAction);
            
            builder.HasMany(m => m.OrderItems).WithOne(m => m.Order).IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
