using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.net.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_clientID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Restaurant_restaurantId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "CategoryRestaurant");

            migrationBuilder.RenameColumn(
                name: "clientID",
                table: "Reservation",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservation",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_clientID",
                table: "Reservation",
                newName: "IX_Reservation_clientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Client",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "restaurantId",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_RestaurantId",
                table: "Category",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Restaurant_RestaurantId",
                table: "Category",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_clientId",
                table: "Reservation",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Restaurant_restaurantId",
                table: "Reservation",
                column: "restaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Restaurant_RestaurantId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_clientId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Restaurant_restaurantId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Category_RestaurantId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Reservation",
                newName: "clientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservation",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_clientId",
                table: "Reservation",
                newName: "IX_Reservation_clientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "restaurantId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clientID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryRestaurant",
                columns: table => new
                {
                    RestaurantsId = table.Column<int>(type: "int", nullable: false),
                    categoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRestaurant", x => new { x.RestaurantsId, x.categoriesId });
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Category_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Restaurant_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRestaurant_categoriesId",
                table: "CategoryRestaurant",
                column: "categoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_clientID",
                table: "Reservation",
                column: "clientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Restaurant_restaurantId",
                table: "Reservation",
                column: "restaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
