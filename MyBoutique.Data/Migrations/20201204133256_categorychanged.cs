using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBoutique.Data.Migrations
{
    public partial class categorychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryTypeId",
                table: "Products",
                column: "CategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryTypeId",
                table: "Products",
                column: "CategoryTypeId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
