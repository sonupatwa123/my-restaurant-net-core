using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public  class RestaurantTimingConfiguration: IEntityTypeConfiguration<RestaurantTiming>
    {      
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RestaurantTiming> builder)
        {
            builder.ToTable("RestaurantTimings").HasOne(m => m.Restaurant);

        }
    }
}
