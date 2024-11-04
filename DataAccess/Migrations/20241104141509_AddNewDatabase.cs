using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 29, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 24, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 15, 14, 15, 7, 913, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 11, 4, 14, 15, 8, 26, DateTimeKind.Utc).AddTicks(8725), "$2a$11$pJOa2qiiOopsX0K/nGa7CukOT704/9ZE7pG6wg15En3zjdKLkG3Jm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 11, 22, 12, 53, 40, 109, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 11, 17, 12, 53, 40, 109, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 11, 8, 12, 53, 40, 109, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 28, 12, 53, 40, 225, DateTimeKind.Utc).AddTicks(8501), "$2a$11$FcHGQs9xE7hzwV2i6sl.IuT3TiFOUiA7IX.PP3jlP46r.Faya6EWm" });
        }
    }
}
