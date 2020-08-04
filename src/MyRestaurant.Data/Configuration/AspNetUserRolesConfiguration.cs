//using Microsoft.EntityFrameworkCore;
//using MyRestaurant.Model.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace MyRestaurant.Data.Configuration
//{
//    public class AspNetUserRolesConfiguration: IEntityTypeConfiguration<AspNetUserRoles>
//    {
//        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AspNetUserRoles> builder)
//        {
//            builder.ToTable("AspNetUserRoles", "dbo")
//                .HasKey(m => new { m.UserId, m.RoleId });

//            builder.HasOne(m => m.Role)
//            .WithMany(m => m.UserRoles)
//            .IsRequired();

//            builder.HasOne(m => m.User).WithMany(m => m.Roles).IsRequired();
//        }
//    }
//}
