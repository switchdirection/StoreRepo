using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntityGameEntity_Categories_CategoryId",
                table: "CategoryEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperEntityGameEntity_Developers_DeveloperId",
                table: "DeveloperEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityOrderEntity_Orders_OrderId",
                table: "GameEntityOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPlatformEntity_Platform_PlatformId",
                table: "GameEntityPlatformEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPublisherEntity_Publisher_PublisherId",
                table: "GameEntityPublisherEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityWishlistEntity_Wishlist_WishlistId",
                table: "GameEntityWishlistEntity");

            migrationBuilder.RenameColumn(
                name: "WishlistId",
                table: "GameEntityWishlistEntity",
                newName: "WishlistsWishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityWishlistEntity_WishlistId",
                table: "GameEntityWishlistEntity",
                newName: "IX_GameEntityWishlistEntity_WishlistsWishlistId");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "GameEntityPublisherEntity",
                newName: "PublishersPublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityPublisherEntity_PublisherId",
                table: "GameEntityPublisherEntity",
                newName: "IX_GameEntityPublisherEntity_PublishersPublisherId");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "GameEntityPlatformEntity",
                newName: "PlatformsPlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityPlatformEntity_PlatformId",
                table: "GameEntityPlatformEntity",
                newName: "IX_GameEntityPlatformEntity_PlatformsPlatformId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "GameEntityOrderEntity",
                newName: "OrdersOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityOrderEntity_OrderId",
                table: "GameEntityOrderEntity",
                newName: "IX_GameEntityOrderEntity_OrdersOrderId");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "DeveloperEntityGameEntity",
                newName: "DevelopersDeveloperId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryEntityGameEntity",
                newName: "CategoriesCategoryId");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelegramChatId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationChannel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationChannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationChannel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationChannel_ApplicationUserId",
                table: "NotificationChannel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntityGameEntity_Categories_CategoriesCategoryId",
                table: "CategoryEntityGameEntity",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperEntityGameEntity_Developers_DevelopersDeveloperId",
                table: "DeveloperEntityGameEntity",
                column: "DevelopersDeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityOrderEntity_Orders_OrdersOrderId",
                table: "GameEntityOrderEntity",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPlatformEntity_Platform_PlatformsPlatformId",
                table: "GameEntityPlatformEntity",
                column: "PlatformsPlatformId",
                principalTable: "Platform",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPublisherEntity_Publisher_PublishersPublisherId",
                table: "GameEntityPublisherEntity",
                column: "PublishersPublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityWishlistEntity_Wishlist_WishlistsWishlistId",
                table: "GameEntityWishlistEntity",
                column: "WishlistsWishlistId",
                principalTable: "Wishlist",
                principalColumn: "WishlistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntityGameEntity_Categories_CategoriesCategoryId",
                table: "CategoryEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperEntityGameEntity_Developers_DevelopersDeveloperId",
                table: "DeveloperEntityGameEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityOrderEntity_Orders_OrdersOrderId",
                table: "GameEntityOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPlatformEntity_Platform_PlatformsPlatformId",
                table: "GameEntityPlatformEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityPublisherEntity_Publisher_PublishersPublisherId",
                table: "GameEntityPublisherEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEntityWishlistEntity_Wishlist_WishlistsWishlistId",
                table: "GameEntityWishlistEntity");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NotificationChannel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WishlistsWishlistId",
                table: "GameEntityWishlistEntity",
                newName: "WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityWishlistEntity_WishlistsWishlistId",
                table: "GameEntityWishlistEntity",
                newName: "IX_GameEntityWishlistEntity_WishlistId");

            migrationBuilder.RenameColumn(
                name: "PublishersPublisherId",
                table: "GameEntityPublisherEntity",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityPublisherEntity_PublishersPublisherId",
                table: "GameEntityPublisherEntity",
                newName: "IX_GameEntityPublisherEntity_PublisherId");

            migrationBuilder.RenameColumn(
                name: "PlatformsPlatformId",
                table: "GameEntityPlatformEntity",
                newName: "PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityPlatformEntity_PlatformsPlatformId",
                table: "GameEntityPlatformEntity",
                newName: "IX_GameEntityPlatformEntity_PlatformId");

            migrationBuilder.RenameColumn(
                name: "OrdersOrderId",
                table: "GameEntityOrderEntity",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_GameEntityOrderEntity_OrdersOrderId",
                table: "GameEntityOrderEntity",
                newName: "IX_GameEntityOrderEntity_OrderId");

            migrationBuilder.RenameColumn(
                name: "DevelopersDeveloperId",
                table: "DeveloperEntityGameEntity",
                newName: "DeveloperId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryEntityGameEntity",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "releasedate",
                value: new DateTime(2024, 10, 26, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "releasedate",
                value: new DateTime(2024, 10, 21, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "releasedate",
                value: new DateTime(2024, 10, 12, 15, 55, 25, 198, DateTimeKind.Utc).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createat", "password" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 55, 25, 585, DateTimeKind.Utc).AddTicks(7773), "$2a$11$okuo4Of2szf//qdPip3U4.3BwZIZt2kcoRe72KmWNgYgL3jgjYmpy" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntityGameEntity_Categories_CategoryId",
                table: "CategoryEntityGameEntity",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperEntityGameEntity_Developers_DeveloperId",
                table: "DeveloperEntityGameEntity",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityOrderEntity_Orders_OrderId",
                table: "GameEntityOrderEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPlatformEntity_Platform_PlatformId",
                table: "GameEntityPlatformEntity",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityPublisherEntity_Publisher_PublisherId",
                table: "GameEntityPublisherEntity",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEntityWishlistEntity_Wishlist_WishlistId",
                table: "GameEntityWishlistEntity",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "WishlistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
