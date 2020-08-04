using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo")
                .HasMany(m => m.Orders);

            builder.HasMany(m => m.Feedbacks);
            builder.HasOne(m => m.Address).WithOne(m=>m.User);
            builder.HasMany(m => m.AddressBooks);
        }
    }
}
