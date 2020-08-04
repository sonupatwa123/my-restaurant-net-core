using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class DeliveryAreaConfiguration : IEntityTypeConfiguration<DeliveryArea>
    {        
       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryArea> builder)
        {
            builder.ToTable("DeliveryArea", "dbo")
                .HasOne(m=>m.Restaurant)
                .WithMany(m=>m.DeliveryAreas)
                .IsRequired();
        }
    }
}
