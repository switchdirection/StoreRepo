using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class recreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 19, 12, 6, 19, 184, DateTimeKind.Utc).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 14, 12, 6, 19, 184, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 5, 12, 6, 19, 184, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 25, 12, 6, 19, 567, DateTimeKind.Utc).AddTicks(3244), "$2a$11$h9ZTwGehUj6.WaGFNmZ.WOu48Q3aLZSS45Rox6djYVPxxrM3Q2Or." });
        }
    }
}
