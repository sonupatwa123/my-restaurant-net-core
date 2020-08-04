using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
  public  class RatingConfiguration: IEntityTypeConfiguration<Rating>
    {       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings", "dbo").HasOne(m => m.Restaurant);
            builder.HasOne(m => m.User).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
