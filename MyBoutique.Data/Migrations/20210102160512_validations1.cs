using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBoutique.Data.Migrations
{
    public partial class validations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInformation",
                table: "OrdersData",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInformation",
                table: "OrdersData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);
        }
    }
}
