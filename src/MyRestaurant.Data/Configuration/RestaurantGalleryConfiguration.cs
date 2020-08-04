using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class RestaurantGalleryConfiguration: IEntityTypeConfiguration<RestaurantGallery>
    {    
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RestaurantGallery> builder)
        {
            builder.ToTable("RestaurantGalleries", "dbo")
                .HasOne(m => m.Restaurant);
            builder.HasOne(m => m.Gallery);
        }
    }
}
