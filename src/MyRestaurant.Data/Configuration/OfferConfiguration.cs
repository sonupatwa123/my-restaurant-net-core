using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class OfferConfiguration: IEntityTypeConfiguration<Offer>
    {     
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers")
                .HasMany(m => m.OfferItems);

            builder.HasOne(m => m.Restaurant)
                .WithMany(m => m.Offers).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
