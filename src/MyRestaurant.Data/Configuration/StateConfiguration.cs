using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
   public class StateConfiguration:IEntityTypeConfiguration<State>
    {       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States", "dbo")
                .HasMany(m => m.Cities).WithOne(m => m.State).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Country).WithMany(m => m.States).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(m => m.Addresses);
        }
    }
}
