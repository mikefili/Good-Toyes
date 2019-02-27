using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToyes.Migrations.GoodToyesDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

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
                    Image = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Quantity", "SKU" },
                values: new object[,]
                {
                    { 1, "Your puppers will love this tasty toy from south of the border!", "Assets/Products/avacado_toy.png", "Avacado's Nibbler", 12.95m, 0, "DT00001" },
                    { 2, "You can't got wrong with this time-tested classic.", "Assets/Products/bone_toy.png", "Throw Me A Bone", 8.95m, 0, "DT00002" },
                    { 3, "A fine, feathered friend for your four-legged friend!", "Assets/Products/chicken_toy.png", "Cluckin' Good Time", 12.95m, 0, "DT00003" },
                    { 4, "Perfect side toy for your doggo's morning puppaccino!", "Assets/Products/donut_toy.png", "Donut Bother Me", 12.95m, 0, "DT00004" },
                    { 5, "Barbeque sauce sold separately.", "Assets/Products/drumstick_toy.png", "Ain't No Thing Like A Chicken Wing", 12.95m, 0, "DT00005" },
                    { 6, "WARNING: May turn your pooch into an old timey movie villain.", "Assets/Products/mustache_toy.png", "I Mustache You A Question", 13.95m, 0, "DT00006" },
                    { 7, "That classic thin-crust your dog loves, now in plush!", "Assets/Products/pizza_toy.png", "Pizza My Heart", 12.95m, 0, "DT00007" },
                    { 8, "To the victor, go the spoils!", "Assets/Products/rope_toy.png", "Pug'o'War", 7.95m, 0, "DT00008" },
                    { 9, "Give your woofer the beautiful pearly whites they deserve.", "Assets/Products/smile_toy.png", "Doggy Dentures", 13.95m, 0, "DT00009" },
                    { 10, "Set of three extra jingly tennis balls.", "Assets/Products/tennis_balls.png", "Jingle Balls", 8.95m, 0, "DT00010" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
