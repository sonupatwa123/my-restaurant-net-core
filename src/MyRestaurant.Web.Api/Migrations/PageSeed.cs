using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurant.Web.Api.Migrations
{
    public class PageSeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] ON");
            migrationBuilder.InsertData("Pages", new string[] {
            "Id",
            "Name",
            "IconClass",
            "Url",
            "ActionName",
            "ControllerName",
            "CreatedDate",
            "UpdatedDate",
                "IsDeleted"
            },

                new object[] {
               1,
               "Menu",
               "",
               "/Menu/List",
               "List",
               "Menu",
               DateTime.Now,
               DateTime.Now,
               false
                });

            migrationBuilder.InsertData("Pages", new string[] {
            "Id",
            "Name",
            "IconClass",
            "Url",
            "ActionName",
            "ControllerName",
            "CreatedDate",
            "UpdatedDate",
                "IsDeleted"
            },

                new object[] {
                2,
                "Add Menu",
                2,
                "",
                "/Menu/Save",
                "Save",
                "Menu",
                DateTime.Now,
                DateTime.Now,
               false
                });


            migrationBuilder.InsertData("Pages", new string[] {
            "Id",
            "Name",
            "IconClass",
            "Url",
            "ActionName",
            "ControllerName",
            "CreatedDate",
            "UpdatedDate",
                "IsDeleted"
            },

            new object[] {
                3,
                "Restaurant",
                null,
                "",
                "/Restaurant/List",
                "List",
                "Restaurant",
                DateTime.Now,
                DateTime.Now,
               false
            });
            migrationBuilder.InsertData("Pages", new string[] {
            "Id",
            "Name",
            "IconClass",
            "Url",
            "ActionName",
            "ControllerName",
            "CreatedDate",
            "UpdatedDate",
                "IsDeleted"
            },

            new object[] {
                4,
                "Add Restaurant",
                3,
                "",
                "/Restaurant/Save",
                "Save",
                "Restaurant",
                DateTime.Now,
                DateTime.Now,
               false
            });

            migrationBuilder.InsertData("Pages", new string[] {
            "Id",
            "Name",
            "IconClass",
            "Url",
            "ActionName",
            "ControllerName",
            "CreatedDate",
            "UpdatedDate",
                "IsDeleted"
            },

                new object[] {
                5,
                "Pages",
                3,
                "",
                "/Restaurant/Save",
                "Save",
                "Restaurant",
                DateTime.Now,
                DateTime.Now,
               false
                });
            migrationBuilder.Sql("Set IDENTITY_INSERT [dbo].[MenuCategories] OFF");
        }
    }
}
