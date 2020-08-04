using MyRestaurant.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurant.Data.Configuration
{
  public  class ReservationConfiguration: IEntityTypeConfiguration<Reservation>
    {     
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations")
                .HasOne(m => m.User);

            builder.HasOne(m => m.Restaurant);
        }
    }
}
