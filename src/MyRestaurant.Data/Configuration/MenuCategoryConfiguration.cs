using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
    public class MenuCategoryConfiguration: IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuCategory> builder)
        {
            builder.ToTable("MenuCategories", "dbo");
        }
    }
}
