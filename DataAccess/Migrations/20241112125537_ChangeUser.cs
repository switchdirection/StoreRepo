using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserIdId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_UserIdId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WalletBalance",
                table: "AspNetUsers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Wishlistid",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Wishlistid",
                table: "AspNetUsers",
                column: "Wishlistid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wishlist_Wishlistid",
                table: "AspNetUsers",
                column: "Wishlistid",
                principalTable: "Wishlist",
                principalColumn: "WishlistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_userid",
                table: "Carts",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserIdId",
                table: "Review",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wishlist_Wishlistid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_userid",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserIdId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Wishlistid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WalletBalance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Wishlistid",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Wishlistid = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    WalletBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Wishlist_Wishlistid",
                        column: x => x.Wishlistid,
                        principalTable: "Wishlist",
                        principalColumn: "WishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CartId", "createat", "email", "password", "role", "username", "WalletBalance", "Wishlistid" },
                values: new object[] { 1, 0, new DateTime(2024, 11, 12, 12, 37, 26, 560, DateTimeKind.Utc).AddTicks(1423), "swwtdirrexamplemail@gmail.com", "$2a$11$klhZZqIaC5eUbCkivCRrUuk8DzuBFxhK3tGGq0bhnl6UvivHCwa9q", "user", "swwtdirr", 100m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wishlistid",
                table: "Users",
                column: "Wishlistid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts",
                column: "userid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserIdId",
                table: "Orders",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_UserIdId",
                table: "Review",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
