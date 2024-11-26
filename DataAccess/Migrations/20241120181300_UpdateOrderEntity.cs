using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityOrderEntity_Games_GameIdId",
                table: "GameEntityOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserIdId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "GameIdId",
                table: "GameEntityOrderEntity",
                newName: "GamesId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityOrderEntity_Games_GamesId",
                table: "GameEntityOrderEntity",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityOrderEntity_Games_GamesId",
                table: "GameEntityOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameEntityOrderEntity",
                newName: "GameIdId");

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdId",
                table: "Orders",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityOrderEntity_Games_GameIdId",
                table: "GameEntityOrderEntity",
                column: "GameIdId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
