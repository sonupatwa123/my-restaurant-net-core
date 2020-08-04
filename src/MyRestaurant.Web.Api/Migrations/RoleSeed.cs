using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurant.Web.Api.Migrations
{
    public class RoleSeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Roles", new string[] {
                "Id",
                "Name"
            }, new object[] {
                "07011725-6990-45E9-84AA-5AD12127A52F",
                "SystemAdmin"
            });
            migrationBuilder.InsertData("Roles", new string[] {
                "Id",
                "Name"
            }, new object[] { "5781FEC0-82B9-4D87-8F0A-56D6E771B4FD", "Administrator" });
            migrationBuilder.InsertData("Roles", new string[] {
                "Id",
                "Name"
            }, new object[] { "723B962D-519A-4596-977D-94C32C526CF5", "Restaurant" });
            migrationBuilder.InsertData("Roles", new string[] {
                "Id",
                "Name"
            }, new object[] { "090245e4-3772-4b9e-afb1-8eb54080916b", "User" });

        }
    }
}
