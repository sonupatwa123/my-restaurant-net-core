using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Web.Api.Migrations
{
    public class MenuCategorySeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] OFF");

            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] ON");

            migrationBuilder.InsertData("MenuCategories", new string[] {
                "Id",
                "Name",
                "IsGlobal",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
            },
            new object[] {
                 1,
                "Break Fast",
                true,
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
            });

            migrationBuilder.InsertData("MenuCategories", new string[] {
                "Id",
                "Name",
                "IsGlobal",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
            },
          new object[] {
                2,
             "Lunch",
                true,                
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });

            migrationBuilder.InsertData("MenuCategories", new string[] {
                "Id",
                "Name",
                "IsGlobal",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
            },
           new object[] {
               3,
               "Dinner",
               true,
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
           });
            migrationBuilder.InsertData("MenuCategories", new string[] {
                "Id",
                "Name",
                "IsGlobal",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
            },
          new object[] {
                4,
                "Snacks",
                true,
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });

            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] OFF");
        }
    }
}
