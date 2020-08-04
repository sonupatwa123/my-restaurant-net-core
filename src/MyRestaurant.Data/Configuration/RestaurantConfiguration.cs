using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class RestaurantConfiguration: IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant", "dbo")
                .HasMany(m => m.Orders)
                .WithOne(m => m.Restaurant).IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Ratings);
            builder.HasMany(m => m.DeliveryAreas);
            //builder.HasOne(m => m.User);
            builder.HasMany(m => m.Menus);
            builder.HasMany(m => m.Feedbacks);
            builder.HasMany(m => m.Offers);
            builder.HasMany(m => m.DeliveryFees)
                .WithOne(m => m.Restaurant).IsRequired();
        }
    }
}
