using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class FeedbackConfiguration: IEntityTypeConfiguration<Feedback>
    {        
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback", "dbo")
                .HasOne(r=>r.Restaurant)
                .WithMany(m=>m.Feedbacks)
                .IsRequired();

            builder.HasOne(u => u.User);
        }
    }
}
