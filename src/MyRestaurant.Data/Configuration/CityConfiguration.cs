using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City", "dbo").HasKey(m => m.Id);

            builder.HasOne(m => m.State)
            .WithMany(m => m.Cities)
            .IsRequired(true)
          .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Addresses)
                .WithOne(m => m.City)
                .IsRequired(true);
        }
    }
}
