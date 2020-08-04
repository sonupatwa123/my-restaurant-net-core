using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class OrderItemConfiguration: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "dbo")
                 .HasOne(m => m.Order);

            builder.HasOne(m => m.MenuItem).WithMany(m => m.OrderItems).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
