using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Images",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Games_GameId",
                table: "Images",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
