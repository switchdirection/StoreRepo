using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "categoryname" },
                values: new object[,]
                {
                    { 1, "RPG" },
                    { 2, "Action RPG" },
                    { 3, "Rougelike" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 38, 1, 702, DateTimeKind.Utc).AddTicks(1049), "$2a$11$3ehhyRBCB4ub.kecos2i6OwYT1VRl7ikmmjVPKE7Qd5Ddn1B58pAC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 23, 48, 14, DateTimeKind.Utc).AddTicks(9866), "$2a$11$kVcKb/9/QV6NDfcJlkF74.i0weRTgEukxxy07n6bHvnlIj8Sfb1kG" });
        }
    }
}
