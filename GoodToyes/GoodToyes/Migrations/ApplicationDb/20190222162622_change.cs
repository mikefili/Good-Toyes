using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToyes.Migrations.ApplicationDb
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SpayedOrNeutered",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpayedOrNeutered",
                table: "AspNetUsers");
        }
    }
}
