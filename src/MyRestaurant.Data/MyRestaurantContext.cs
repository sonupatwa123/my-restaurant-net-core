using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Data
{
    public class MyRestaurantContext : DbContext
    {
        public MyRestaurantContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.Namespace == "MyRestaurant.Data.Configuration");
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaidMethod> PaidMethods { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<Restaurant> RestaurantDetails { get; set; }

        //public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

        public DbSet<Address> Address { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public DbSet<DeliveryArea> DeliveryAreas { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

        public DbSet<MenuCategory> MenuCategories { get; set; }

        public DbSet<Page> Pages { get; set; }
        public DbSet<UserRoleToPage> UserRoleToPages { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                var entity = entry.Entity;
                var state = entry.State;

                if (state.HasFlag(EntityState.Added))
                {
                    entity.CreatedDate = now;
                    entity.UpdatedDate = now;
                }

                if (state.HasFlag(EntityState.Modified))
                {
                    entity.UpdatedDate = now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
