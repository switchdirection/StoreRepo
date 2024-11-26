using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperEntityGameEntity_Games_GameIdId",
                table: "DeveloperEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPlatformEntity_Games_GameIdId",
                table: "GameEntityPlatformEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPublisherEntity_Games_GameIdId",
                table: "GameEntityPublisherEntity");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "GameIdId",
                table: "GameEntityPublisherEntity",
                newName: "GamesId");

            migrationBuilder.RenameColumn(
                name: "GameIdId",
                table: "GameEntityPlatformEntity",
                newName: "GamesId");

            migrationBuilder.RenameColumn(
                name: "GameIdId",
                table: "DeveloperEntityGameEntity",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_DeveloperEntityGameEntity_GameIdId",
                table: "DeveloperEntityGameEntity",
                newName: "IX_DeveloperEntityGameEntity_GamesId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 11, 8, 12, 14, 38, 188, DateTimeKind.Utc).AddTicks(3885), "$2a$11$DCsPDtXVU2.DwQeklquGzO2YSNxwKxE.zPjgS2OTbcJjDmHa50PjW" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperEntityGameEntity_Games_GamesId",
                table: "DeveloperEntityGameEntity",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPlatformEntity_Games_GamesId",
                table: "GameEntityPlatformEntity",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPublisherEntity_Games_GamesId",
                table: "GameEntityPublisherEntity",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperEntityGameEntity_Games_GamesId",
                table: "DeveloperEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPlatformEntity_Games_GamesId",
                table: "GameEntityPlatformEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPublisherEntity_Games_GamesId",
                table: "GameEntityPublisherEntity");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameEntityPublisherEntity",
                newName: "GameIdId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameEntityPlatformEntity",
                newName: "GameIdId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "DeveloperEntityGameEntity",
                newName: "GameIdId");

            migrationBuilder.RenameIndex(
                name: "IX_DeveloperEntityGameEntity_GamesId",
                table: "DeveloperEntityGameEntity",
                newName: "IX_DeveloperEntityGameEntity_GameIdId");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "description", "IsDeleted", "price", "rating", "releasedate", "StockQuantity", "title" },
                values: new object[,]
                {
                    { 1, "Прикольные гоночки", false, 14.99, 5.0, new DateTime(2024, 11, 29, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8497), 0, "Need For Speed" },
                    { 2, "Что-то про мужика который прыгает по крышам", false, 59.990000000000002, 4.7000000000000002, new DateTime(2024, 11, 24, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8506), 0, "Assasin Creed" },
                    { 3, "Что-то про мужиков которые стреляют", false, 14.99, 4.9000000000000004, new DateTime(2024, 11, 15, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8509), 0, "Call Of Duty" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 11, 4, 14, 15, 8, 26, DateTimeKind.Utc).AddTicks(8725), "$2a$11$pJOa2qiiOopsX0K/nGa7CukOT704/9ZE7pG6wg15En3zjdKLkG3Jm" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperEntityGameEntity_Games_GameIdId",
                table: "DeveloperEntityGameEntity",
                column: "GameIdId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPlatformEntity_Games_GameIdId",
                table: "GameEntityPlatformEntity",
                column: "GameIdId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPublisherEntity_Games_GameIdId",
                table: "GameEntityPublisherEntity",
                column: "GameIdId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
