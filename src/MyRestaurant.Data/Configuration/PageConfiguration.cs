using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class PageEntityConfiguration : IEntityTypeConfiguration<Page>
    {       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages", "dbo").HasMany(m => m.Pages)
                .WithOne(m=>m.Parent)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
