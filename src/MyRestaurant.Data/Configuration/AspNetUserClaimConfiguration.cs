//using Microsoft.EntityFrameworkCore;
//using MyRestaurant.Model.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace MyRestaurant.Data.Configuration
//{
//    public class AspNetUserClaimConfiguration : IEntityTypeConfiguration<AspNetUserClaim>
//    {
//        public void Configure(EntityTypeBuilder<AspNetUserClaim> builder)
//        {
//            builder.ToTable("dbo.AspNetUserClaims");

//            builder.HasOne(m => m.User)
//            .WithMany(u => u.AspNetUserClaims)
//            .IsRequired(true).OnDelete(DeleteBehavior.NoAction);
//        }
//    }
//}
