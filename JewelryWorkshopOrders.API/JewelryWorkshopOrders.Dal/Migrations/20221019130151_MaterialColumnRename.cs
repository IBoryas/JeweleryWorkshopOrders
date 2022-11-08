using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryWorkshopOrders.Dal.Migrations
{
    public partial class MaterialColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialType_CategoryId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Materials",
                newName: "MaterialTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials",
                newName: "IX_Materials_MaterialTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialType_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialType_MaterialTypeId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "Materials",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                newName: "IX_Materials_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialType_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
