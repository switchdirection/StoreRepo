using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeDataInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "rating",
                table: "Games",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "developername", "url" },
                values: new object[,]
                {
                    { 1, "Ubisoft", "https://www.ubisoft.com/ru-ru/" },
                    { 2, "Electronic Arts", "https://www.ea.com/ru-ru" },
                    { 3, "Activision Blizzard", "https://www.activisionblizzard.com/" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "description", "price", "rating", "releasedate", "title" },
                values: new object[,]
                {
                    { 1, "Прикольные гоночки", 14.99, 5.0, new DateTime(2024, 10, 26, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5270), "Need For Speed" },
                    { 2, "Что-то про мужика который прыгает по крышам", 59.990000000000002, 4.7000000000000002, new DateTime(2024, 10, 21, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5280), "Assasin Creed" },
                    { 3, "Что-то про мужиков которые стреляют", 14.99, 4.9000000000000004, new DateTime(2024, 10, 12, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5283), "Call Of Duty" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "PlatformId", "platformname" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "XBOX" },
                    { 3, "PlayStation" },
                    { 4, "Android & IOS" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "PublisherId", "publishername", "url" },
                values: new object[,]
                {
                    { 1, "Mojang Studios", "https://www.minecraft.net/en-us/article/meet-mojang-studios" },
                    { 2, "Ubisoft Pune", "https://www.ubisoft.com/en-us/company/careers/locations/pune" },
                    { 3, "Valve", "https://www.valvesoftware.com/ru/" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 55, 25, 585, DateTimeKind.Utc).AddTicks(7773), "$2a$11$okuo4Of2szf//qdPip3U4.3BwZIZt2kcoRe72KmWNgYgL3jgjYmpy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "PlatformId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "PlatformId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "PlatformId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "PlatformId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "PublisherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "PublisherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "PublisherId",
                keyValue: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "rating",
                table: "Games",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 38, 1, 702, DateTimeKind.Utc).AddTicks(1049), "$2a$11$3ehhyRBCB4ub.kecos2i6OwYT1VRl7ikmmjVPKE7Qd5Ddn1B58pAC" });
        }
    }
}
