using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryWorkshopOrders.Dal.Migrations
{
    public partial class Del_FinalWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalWeight",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalWeight",
                table: "Orders",
                type: "float",
                nullable: true);
        }
    }
}
