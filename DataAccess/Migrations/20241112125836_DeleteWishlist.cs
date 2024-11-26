using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeleteWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wishlist_Wishlistid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GameEntityWishlistEntity");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Wishlistid",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistId);
                });

            migrationBuilder.CreateTable(
                name: "GameEntityWishlistEntity",
                columns: table => new
                {
                    GameIdId = table.Column<int>(type: "integer", nullable: false),
                    WishlistsWishlistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityWishlistEntity", x => new { x.GameIdId, x.WishlistsWishlistId });
                    table.ForeignKey(
                        name: "FK_GameEntityWishlistEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityWishlistEntity_Wishlist_WishlistsWishlistId",
                        column: x => x.WishlistsWishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "WishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "WishlistId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Wishlistid",
                table: "AspNetUsers",
                column: "Wishlistid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityWishlistEntity_WishlistsWishlistId",
                table: "GameEntityWishlistEntity",
                column: "WishlistsWishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wishlist_Wishlistid",
                table: "AspNetUsers",
                column: "Wishlistid",
                principalTable: "Wishlist",
                principalColumn: "WishlistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
