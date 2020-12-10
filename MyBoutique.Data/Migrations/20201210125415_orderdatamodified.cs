using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBoutique.Data.Migrations
{
    public partial class orderdatamodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "OrderDatas",
                newName: "City");

            migrationBuilder.AddColumn<int>(
                name: "OrderDataId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "OrderDatas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDataId",
                table: "Orders",
                column: "OrderDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDatas_OrderDataId",
                table: "Orders",
                column: "OrderDataId",
                principalTable: "OrderDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDatas_OrderDataId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDataId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDataId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "OrderDatas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderDatas");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "OrderDatas",
                newName: "Adress");
        }
    }
}
