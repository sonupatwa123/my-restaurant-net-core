using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurant.Web.Api.Migrations
{
    public partial class static_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CuisineSeed.Insert(migrationBuilder);
            DeliveryTypeSeed.Insert(migrationBuilder);
            MenuCategorySeed.Insert(migrationBuilder);
            PageSeed.Insert(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
