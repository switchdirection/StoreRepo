using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BigTablesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Games_GameIdId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GameIdId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GameIdId",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Images",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Images",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Games",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsDeleted", "releasedate", "StockQuantity" },
                values: new object[] { false, new DateTime(2024, 11, 22, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8606), 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsDeleted", "releasedate", "StockQuantity" },
                values: new object[] { false, new DateTime(2024, 11, 17, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8615), 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsDeleted", "releasedate", "StockQuantity" },
                values: new object[] { false, new DateTime(2024, 11, 8, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8640), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 28, 10, 59, 12, 983, DateTimeKind.Utc).AddTicks(3778), "$2a$11$lfr6LXrfWUh1A2Uub7G7OeYBQJX1V.gH66Oitcyq5uXMiWQY.8ZEy" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GameId",
                table: "Images",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GameId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameIdId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 19, 12, 13, 7, 793, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 14, 12, 13, 7, 793, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 5, 12, 13, 7, 793, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 25, 12, 13, 7, 906, DateTimeKind.Utc).AddTicks(2438), "$2a$11$AA3/Y8I4Vjk0j9gN5dCrfeSMDUH3vFZB.baO8odxf65h2iH2UJCMW" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GameIdId",
                table: "Images",
                column: "GameIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Games_GameIdId",
                table: "Images",
                column: "GameIdId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
