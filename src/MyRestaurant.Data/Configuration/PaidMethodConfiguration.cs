using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class PaidMethodConfiguration:IEntityTypeConfiguration<PaidMethod>
    {       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PaidMethod> builder)
        {
            builder.ToTable("PaidMethods", "dbo").HasMany(m => m.Orders);

        }
    }
}
