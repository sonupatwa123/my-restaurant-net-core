using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurant.Web.Api.Migrations
{
    public class UserSeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Roles", new string[] {
                "Id",
                "UserId",
                "FirstName",
                "LastName",
                "EmailAddress",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
            },
            new object[] {
            1000,
            "1F109894-9942-4D28-89CD-3BD7B9993F4D",
            "Jasmeet",
            "Singh",
            "admin@mailinator.com",
            DateTime.Now,
            DateTime.Now,
            "1F109894-9942-4D28-89CD-3BD7B9993F4D",
            "1F109894-9942-4D28-89CD-3BD7B9993F4D",
            false
            });
        }
    }
}
