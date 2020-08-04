using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRestaurant.Data;
using MyRestaurant.Data.Interfaces;

namespace MyRestaurant.Web.Api
{
    public partial class Startup
    {
        private void RegisterDbRepository(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MyRestaurant");

            services.AddDbContext<MyRestaurantContext>(options => {
                options.UseSqlServer(connectionString, m=>m.MigrationsAssembly("MyRestaurant.Web.Api"));
            });

            services.AddScoped<IUnitOfWork>(m => { return new UnitOfWork(m.GetService<DbContextOptions>()); });
        }
    }
}
