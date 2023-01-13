using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.net.Migrations
{
    /// <inheritdoc />
    public partial class poi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurant",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Reservation",
                newName: "restaurantID");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Reservation",
                newName: "clientID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_restaurantId",
                table: "Reservation",
                newName: "IX_Reservation_restaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_clientId",
                table: "Reservation",
                newName: "IX_Reservation_clientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Category",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Category_RestaurantId",
                table: "Category",
                newName: "IX_Category_RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Restaurant_RestaurantID",
                table: "Category",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_clientID",
                table: "Reservation",
                column: "clientID",
                principalTable: "Client",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Restaurant_restaurantID",
                table: "Reservation",
                column: "restaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Restaurant_RestaurantID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_clientID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Restaurant_restaurantID",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Restaurant",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "restaurantID",
                table: "Reservation",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "clientID",
                table: "Reservation",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_restaurantID",
                table: "Reservation",
                newName: "IX_Reservation_restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_clientID",
                table: "Reservation",
                newName: "IX_Reservation_clientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Client",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Category",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_RestaurantID",
                table: "Category",
                newName: "IX_Category_RestaurantId");

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
    }
}
