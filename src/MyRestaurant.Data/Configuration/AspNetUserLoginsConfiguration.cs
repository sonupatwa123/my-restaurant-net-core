//using Microsoft.EntityFrameworkCore;
//using MyRestaurant.Model.Entities;

//namespace MyRestaurant.Data.Configuration
//{
//    public class AspNetUserLoginsConfiguration : IEntityTypeConfiguration<AspNetUserLogin>
//    {
//        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AspNetUserLogin> builder)
//        {
//            builder.ToTable("AspNetUserLogins")
//                .HasKey(m => new { m.LoginProvider, m.ProviderKey, m.UserId });

//            builder.HasOne(m => m.User)
//            .WithMany(m => m.AspNetUserLogins)
//            .IsRequired(true)
//            .OnDelete(DeleteBehavior.NoAction);
//        }
//    }
//}
