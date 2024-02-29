using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleShop.Data.Migrations
{
    public partial class addFieldAdminTouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Manager",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Users");
        }
    }
}
