using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Data.Configuration
{
    public class ChefCuisineConfiguration: IEntityTypeConfiguration<ChefCuisine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ChefCuisine> builder)
        {
            builder.ToTable("ChefCuisines", "dbo");
                
                builder.HasOne(m=>m.RestaurantChef)
                .WithMany(m=>m.ChefCuisines)
                .IsRequired(true);

            builder.HasOne(m => m.Cuisine);            
        }
    }
}
