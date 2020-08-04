using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class UserRoleToPageConfiguration: IEntityTypeConfiguration<UserRoleToPage>
    {      
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRoleToPage> builder)
        {
            builder.ToTable("UserRoleToPages", "dbo").HasOne(m => m.Page);
            //builder.HasOne(n => n.Role);
        }
    }
}
