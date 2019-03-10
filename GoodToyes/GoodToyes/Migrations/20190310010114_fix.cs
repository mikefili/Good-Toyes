using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToyes.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Carts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Carts",
                nullable: true);
        }
    }
}
