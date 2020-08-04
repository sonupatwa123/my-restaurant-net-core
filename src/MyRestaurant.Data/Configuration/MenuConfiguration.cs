using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", "dbo")
                 .HasMany(m => m.MenuItems);

            builder.HasOne(r => r.Restaurant)
                .WithMany(m => m.Menus)
                .IsRequired(true);

            builder.HasMany(m => m.OrderItems);

            builder.HasOne(m => m.MenuCategory)
                .WithMany(m => m.Menus)
                .IsRequired();
        }
    }
}
