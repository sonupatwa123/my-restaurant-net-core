using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRestaurant.Data;

namespace MyRestaurant.Web.Api.Migrations
{
    public static class AspNetUserSeed
    {
        public static void Insert(MyRestaurantContext context)
        {

            //context.AspNetUsers.AddOrUpdate(
            //p => p.Id,
            //new Model.Models.AspNetUsers
            //{
            //    Id = "1F109894-9942-4D28-89CD-3BD7B9993F4D",
            //    Email = "admin@mailinator.com",
            //    EmailConfirmed = true,
            //    PasswordHash = "ABSGD9MfeFY5CskhCR6GRwrghxv77rUyDBoY9A2mxdoK7S0k3u4WHD8Fu1H+f6IjGQ==",
            //    SecurityStamp = "d121f3f0-1018-4f63-a8ae-6405da74a0f7",
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnabled = false,
            //    LockoutEndDateUtc = DateTime.Now,
            //    AccessFailedCount = 0,
            //    UserName = "admin@mailinator.com",
            //});
            //context.SaveChanges();

        }
    }
}
