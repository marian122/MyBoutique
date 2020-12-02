using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBoutique.Data.Migrations
{
    public partial class OrderDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDataId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderDataId",
                table: "Carts",
                column: "OrderDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_OrderDatas_OrderDataId",
                table: "Carts",
                column: "OrderDataId",
                principalTable: "OrderDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_OrderDatas_OrderDataId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDatas");

            migrationBuilder.DropIndex(
                name: "IX_Carts_OrderDataId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrderDataId",
                table: "Carts");
        }
    }
}
