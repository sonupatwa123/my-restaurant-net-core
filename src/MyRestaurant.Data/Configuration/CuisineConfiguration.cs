using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
  public  class CuisineConfiguration: IEntityTypeConfiguration<Cuisine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cuisine> builder)
        {
            builder.ToTable("Cuisines")
                .HasMany(m => m.Menus)
                .WithOne(m=>m.Cuisine).IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
