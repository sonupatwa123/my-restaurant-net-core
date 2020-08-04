using MyRestaurant.Model.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Data.Configuration
{
   public  class MenuItemGalleryConfiguration:IEntityTypeConfiguration<MenuItemGallery>
    {        
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuItemGallery> builder)
        {
            builder.ToTable("MenuItemGalleries", "dbo")
                .HasOne(m => m.MenuItem)
                .WithMany(m=>m.MenuItemGalleries)
                .IsRequired();

            builder.HasOne(m => m.Gallery);
        }
    }
}
