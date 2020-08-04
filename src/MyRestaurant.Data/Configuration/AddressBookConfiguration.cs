using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data.Configuration
{
   public class AddressBookConfiguration: IEntityTypeConfiguration<AddressBook>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AddressBook> builder)
        {
            builder.ToTable("AddressBook", "dbo")
                .HasKey(m => m.Id);

            builder.HasOne(m => m.User)
                .WithMany(m => m.AddressBooks)
                .IsRequired(true);
            
        }
    }
}
