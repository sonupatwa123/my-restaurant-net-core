using MyRestaurant.Model.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Data.Configuration
{
    public class RestaurantChefConfiguration: IEntityTypeConfiguration<RestaurantChef>
    {       
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RestaurantChef> builder)
        {
            builder.ToTable("RestaurantChefs", "dbo").HasMany(m => m.ChefCuisines);

        }
    }
}
