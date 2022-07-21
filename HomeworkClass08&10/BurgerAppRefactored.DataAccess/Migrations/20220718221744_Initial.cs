using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerAppRefactored.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurgerOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurgerOrderItem_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerOrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraOrderItem_Extra_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraOrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burger",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "IsVegan", "IsVegetarian", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", false, false, "Regular burger", 200m },
                    { 2, "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", false, false, "Hamburger", 250m },
                    { 3, "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", false, false, "Cheese Burger", 300m }
                });

            migrationBuilder.InsertData(
                table: "Extra",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Fries", 50m },
                    { 2, "Extra2", 100m },
                    { 3, "Extra3", 150m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrderItem_BurgerId",
                table: "BurgerOrderItem",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrderItem_OrderId",
                table: "BurgerOrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOrderItem_ExtraId",
                table: "ExtraOrderItem",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOrderItem_OrderId",
                table: "ExtraOrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerOrderItem");

            migrationBuilder.DropTable(
                name: "ExtraOrderItem");

            migrationBuilder.DropTable(
                name: "Burger");

            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
