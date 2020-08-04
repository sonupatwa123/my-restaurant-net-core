using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class MenuItemConfiguration:IEntityTypeConfiguration<MenuItem>
    {      
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems", "dbo")
                .HasOne(m => m.Menu)
                .WithMany(m=>m.MenuItems)
                .IsRequired();

            builder.HasOne(m => m.DeliveryType)
                .WithMany(m=>m.MenuItems)
                .IsRequired();

            builder.HasOne(m => m.Menu)
                .WithMany(m=>m.MenuItems)
                .IsRequired();

            builder.HasMany(m => m.OrderItems);
        }
    }
}
