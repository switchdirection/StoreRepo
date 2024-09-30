using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    developername = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    releasedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rating = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    platformname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    publishername = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

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
                name: "CategoryEntityGameEntity",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    GameIdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntityGameEntity", x => new { x.CategoryId, x.GameIdId });
                    table.ForeignKey(
                        name: "FK_CategoryEntityGameEntity_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEntityGameEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperEntityGameEntity",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "integer", nullable: false),
                    GameIdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperEntityGameEntity", x => new { x.DeveloperId, x.GameIdId });
                    table.ForeignKey(
                        name: "FK_DeveloperEntityGameEntity_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperEntityGameEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imageurl = table.Column<string>(type: "text", nullable: false),
                    GameIdId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameEntityPlatformEntity",
                columns: table => new
                {
                    GameIdId = table.Column<int>(type: "integer", nullable: false),
                    PlatformId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityPlatformEntity", x => new { x.GameIdId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GameEntityPlatformEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityPlatformEntity_Platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameEntityPublisherEntity",
                columns: table => new
                {
                    GameIdId = table.Column<int>(type: "integer", nullable: false),
                    PublisherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityPublisherEntity", x => new { x.GameIdId, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_GameEntityPublisherEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityPublisherEntity_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameEntityWishlistEntity",
                columns: table => new
                {
                    GameIdId = table.Column<int>(type: "integer", nullable: false),
                    WishlistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityWishlistEntity", x => new { x.GameIdId, x.WishlistId });
                    table.ForeignKey(
                        name: "FK_GameEntityWishlistEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityWishlistEntity_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "WishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    Wishlistid = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIdId = table.Column<int>(type: "integer", nullable: true),
                    totalorderprice = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    purchasedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIdId = table.Column<int>(type: "integer", nullable: true),
                    GameIdId = table.Column<int>(type: "integer", nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    reviewtext = table.Column<string>(type: "text", nullable: false),
                    reviewdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameEntityOrderEntity",
                columns: table => new
                {
                    GameIdId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityOrderEntity", x => new { x.GameIdId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_GameEntityOrderEntity_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityOrderEntity_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntityGameEntity_GameIdId",
                table: "CategoryEntityGameEntity",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperEntityGameEntity_GameIdId",
                table: "DeveloperEntityGameEntity",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityOrderEntity_OrderId",
                table: "GameEntityOrderEntity",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityPlatformEntity_PlatformId",
                table: "GameEntityPlatformEntity",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityPublisherEntity_PublisherId",
                table: "GameEntityPublisherEntity",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityWishlistEntity_WishlistId",
                table: "GameEntityWishlistEntity",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_GameIdId",
                table: "Images",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdId",
                table: "Orders",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_GameIdId",
                table: "Review",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserIdId",
                table: "Review",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Wishlistid",
                table: "Users",
                column: "Wishlistid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEntityGameEntity");

            migrationBuilder.DropTable(
                name: "DeveloperEntityGameEntity");

            migrationBuilder.DropTable(
                name: "GameEntityOrderEntity");

            migrationBuilder.DropTable(
                name: "GameEntityPlatformEntity");

            migrationBuilder.DropTable(
                name: "GameEntityPublisherEntity");

            migrationBuilder.DropTable(
                name: "GameEntityWishlistEntity");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Wishlist");
        }
    }
}
