using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class DeliveryFeesConfiguration:IEntityTypeConfiguration<DeliveryFees>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryFees> builder)
        {
            builder.ToTable("DeliveryFees", "dbo");
        }
    }
}
