using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalTest.Migrations
{
    public partial class addcolumnSO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesOrderNo",
                table: "SalesOrder",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesOrderNo",
                table: "SalesOrder");
        }
    }
}
