using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{

    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", "dbo");

            builder.HasMany(m => m.States)
                .WithOne(m=>m.Country)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Addresses)
                .WithOne(m=>m.Country);
        }
    }
}
