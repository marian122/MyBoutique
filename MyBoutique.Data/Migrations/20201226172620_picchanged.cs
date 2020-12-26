using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBoutique.Data.Migrations
{
    public partial class picchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_OrderId",
                table: "Pictures",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Orders_OrderId",
                table: "Pictures",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Orders_OrderId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_OrderId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pictures");
        }
    }
}
