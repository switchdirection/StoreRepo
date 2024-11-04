using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 22, 11, 36, 15, 138, DateTimeKind.Utc).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 17, 11, 36, 15, 138, DateTimeKind.Utc).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 8, 11, 36, 15, 138, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 28, 11, 36, 15, 249, DateTimeKind.Utc).AddTicks(728), "$2a$11$Lml3tzVaRUljcWPveHJv2uP5oYsjEcHd34UrAZk7Nt5UH0zTEOU0q" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 22, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 17, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 8, 10, 59, 12, 870, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 28, 10, 59, 12, 983, DateTimeKind.Utc).AddTicks(3778), "$2a$11$lfr6LXrfWUh1A2Uub7G7OeYBQJX1V.gH66Oitcyq5uXMiWQY.8ZEy" });
        }
    }
}
