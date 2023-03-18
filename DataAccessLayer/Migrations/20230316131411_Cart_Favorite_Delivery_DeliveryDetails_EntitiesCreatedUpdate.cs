using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Cart_Favorite_Delivery_DeliveryDetails_EntitiesCreatedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetail_Delivery_DeliveryId",
                table: "DeliveryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetail_Products_ProductId",
                table: "DeliveryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryDetail",
                table: "DeliveryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery");

            migrationBuilder.RenameTable(
                name: "DeliveryDetail",
                newName: "DeliveryDetails");

            migrationBuilder.RenameTable(
                name: "Delivery",
                newName: "Deliveries");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDetail_ProductId",
                table: "DeliveryDetails",
                newName: "IX_DeliveryDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDetail_DeliveryId",
                table: "DeliveryDetails",
                newName: "IX_DeliveryDetails_DeliveryId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryDetails",
                table: "DeliveryDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserId",
                table: "Deliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetails_Deliveries_DeliveryId",
                table: "DeliveryDetails",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetails_Products_ProductId",
                table: "DeliveryDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetails_Deliveries_DeliveryId",
                table: "DeliveryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetails_Products_ProductId",
                table: "DeliveryDetails");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryDetails",
                table: "DeliveryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_UserId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deliveries");

            migrationBuilder.RenameTable(
                name: "DeliveryDetails",
                newName: "DeliveryDetail");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Delivery");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDetails_ProductId",
                table: "DeliveryDetail",
                newName: "IX_DeliveryDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDetails_DeliveryId",
                table: "DeliveryDetail",
                newName: "IX_DeliveryDetail_DeliveryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryDetail",
                table: "DeliveryDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivery",
                table: "Delivery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetail_Delivery_DeliveryId",
                table: "DeliveryDetail",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetail_Products_ProductId",
                table: "DeliveryDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
