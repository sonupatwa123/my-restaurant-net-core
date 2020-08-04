using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using MyRestaurant.Data;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Web.Api.Migrations
{
    public class DeliveryTypeSeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] OFF");

            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[DeliveryType] ON");

            migrationBuilder.InsertData("DeliveryType", new string[]{"Id",
                "TypeName",
                "CreatedById",
                "UpdatedById",
                "UpdatedDate",
                "CreatedDate",
                "IsDeleted"
                }, new object[]
            {
                1,
                "Home Delivery",
                 "",
                 "",
                 DateTime.Now,
                 DateTime.Now,
               false
            });

            migrationBuilder.InsertData("DeliveryType", new string[]{"Id",
                "TypeName",
                "CreatedById",
                "UpdatedById",
                "UpdatedDate",
                "CreatedDate",
                "IsDeleted"
                }, new object[]
              {
              2,
              "Pick up",
              "",
              "",
              DateTime.Now,
              DateTime.Now,
               false
            });

            migrationBuilder.InsertData("DeliveryType", new string[]{"Id",
                "TypeName",
                "CreatedById",
                "UpdatedById",
                "UpdatedDate",
                "CreatedDate",
                "IsDeleted"
                }, new object[]
           {
                3,
                "Both",
                "",
                "",
                DateTime.Now,
                DateTime.Now,
               false
            });

            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[DeliveryType] OFF");
        }
    }
}
