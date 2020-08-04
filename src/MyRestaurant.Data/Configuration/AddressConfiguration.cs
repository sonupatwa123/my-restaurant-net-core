using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "dbo")
                .HasKey(m => m.Id);
            builder.HasOne(m => m.City)
                .WithMany(m => m.Addresses)
                .IsRequired(true).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.State)
                .WithMany(m => m.Addresses)
                .IsRequired(true).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Country)
                .WithMany(m => m.Addresses)
                .IsRequired(true).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
