using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("ContactUs", "dbo");

            builder.HasOne(m => m.User)
            .WithMany(m => m.ContactUs)
            .IsRequired(false);
        }
    }
}
