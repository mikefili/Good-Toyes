using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToyes.Migrations.GoodToyesDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Your puppers will love this tasty toy from south of the border!", "Products/avacado_toy.png", "Avacado's Nibbler", 12.95m, "DT00001" },
                    { 2, "You can't got wrong with this time-tested classic.", "Products/bone_toy.png", "Throw Me A Bone", 8.95m, "DT00002" },
                    { 3, "A fine, feathered friend for your four-legged friend!", "Products/chicken_toy.png", "Cluckin' Good Time", 12.95m, "DT00003" },
                    { 4, "Perfect side toy for your doggo's morning puppaccino!", "Products/donut_toy.png", "Donut Bother Me", 12.95m, "DT00004" },
                    { 5, "Barbeque sauce sold separately.", "Products/drumstick_toy.png", "Ain't No Thing Like A Chicken Wing", 12.95m, "DT00005" },
                    { 6, "WARNING: May turn your pooch into an old timey movie villain.", "Products/mustache_toy.png", "I Mustache You A Question", 13.95m, "DT00006" },
                    { 7, "That classic thin-crust your dog loves, now in plush!", "Products/pizza_toy.png", "Pizza My Heart", 12.95m, "DT00007" },
                    { 8, "To the victor, go the spoils!", "Products/rope_toy.png", "Pug'o'War", 7.95m, "DT00008" },
                    { 9, "Give your woofer the beautiful pearly whites they deserve.", "Products/smile_toy.png", "Doggy Dentures", 13.95m, "DT00009" },
                    { 10, "Set of three extra jingly tennis balls.", "Products/tennis_balls.png", "Jingle Balls", 8.95m, "DT00010" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
