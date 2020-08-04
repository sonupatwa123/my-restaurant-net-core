using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class OfferItemConfiguration: IEntityTypeConfiguration<OfferItem>
    {     
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OfferItem> builder)
        {
            builder.ToTable("OfferItems")
                .HasOne(m => m.Offer);

            builder.HasOne(m => m.MenuItem);
        }
    }
}
