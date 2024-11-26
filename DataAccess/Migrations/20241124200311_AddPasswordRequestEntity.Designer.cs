﻿// <auto-generated />
using System;
using DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241124200311_AddPasswordRequestEntity")]
    partial class AddPasswordRequestEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryEntityGameEntity", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.HasKey("CategoriesCategoryId", "GameIdId");

                    b.HasIndex("GameIdId");

                    b.ToTable("CategoryEntityGameEntity");
                });

            modelBuilder.Entity("DeveloperEntityGameEntity", b =>
                {
                    b.Property<int>("DevelopersDeveloperId")
                        .HasColumnType("integer");

                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.HasKey("DevelopersDeveloperId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("DeveloperEntityGameEntity");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<long?>("TelegramChatId")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<decimal>("WalletBalance")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CartEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("categoryname");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "RPG"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Action RPG"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Rougelike"
                        });
                });

            modelBuilder.Entity("Domain.Entities.DeveloperEntity", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeveloperId"));

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("developername");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers", (string)null);

                    b.HasData(
                        new
                        {
                            DeveloperId = 1,
                            DeveloperName = "Ubisoft",
                            WebsiteUrl = "https://www.ubisoft.com/ru-ru/"
                        },
                        new
                        {
                            DeveloperId = 2,
                            DeveloperName = "Electronic Arts",
                            WebsiteUrl = "https://www.ea.com/ru-ru"
                        },
                        new
                        {
                            DeveloperId = 3,
                            DeveloperName = "Activision Blizzard",
                            WebsiteUrl = "https://www.activisionblizzard.com/"
                        });
                });

            modelBuilder.Entity("Domain.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("releasedate");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CartEntityId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ImageEntity", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<int?>("GameId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageurl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ImageId");

                    b.HasIndex("GameId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.NotificationChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("NotificationChannel");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("purchasedate");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("totalorderprice");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OrdersHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrderHistory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PasswordResetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ResetCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PasswordReset");
                });

            modelBuilder.Entity("Domain.Entities.PlatformEntity", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlatformId"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("platformname");

                    b.HasKey("PlatformId");

                    b.ToTable("Platform", (string)null);

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            PlatformName = "Windows"
                        },
                        new
                        {
                            PlatformId = 2,
                            PlatformName = "XBOX"
                        },
                        new
                        {
                            PlatformId = 3,
                            PlatformName = "PlayStation"
                        },
                        new
                        {
                            PlatformId = 4,
                            PlatformName = "Android & IOS"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PublisherEntity", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("publishername");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher", (string)null);

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            PublisherName = "Mojang Studios",
                            WebsiteUrl = "https://www.minecraft.net/en-us/article/meet-mojang-studios"
                        },
                        new
                        {
                            PublisherId = 2,
                            PublisherName = "Ubisoft Pune",
                            WebsiteUrl = "https://www.ubisoft.com/en-us/company/careers/locations/pune"
                        },
                        new
                        {
                            PublisherId = 3,
                            PublisherName = "Valve",
                            WebsiteUrl = "https://www.valvesoftware.com/ru/"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<int?>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reviewdate");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reviewtext");

                    b.Property<int?>("UserIdId")
                        .HasColumnType("integer");

                    b.HasKey("ReviewId");

                    b.HasIndex("GameIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.HasKey("GamesId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("GameEntityOrderEntity");
                });

            modelBuilder.Entity("GameEntityPlatformEntity", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("PlatformsPlatformId")
                        .HasColumnType("integer");

                    b.HasKey("GamesId", "PlatformsPlatformId");

                    b.HasIndex("PlatformsPlatformId");

                    b.ToTable("GameEntityPlatformEntity");
                });

            modelBuilder.Entity("GameEntityPublisherEntity", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("PublishersPublisherId")
                        .HasColumnType("integer");

                    b.HasKey("GamesId", "PublishersPublisherId");

                    b.HasIndex("PublishersPublisherId");

                    b.ToTable("GameEntityPublisherEntity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CategoryEntityGameEntity", b =>
                {
                    b.HasOne("Domain.Entities.CategoryEntity", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeveloperEntityGameEntity", b =>
                {
                    b.HasOne("Domain.Entities.DeveloperEntity", null)
                        .WithMany()
                        .HasForeignKey("DevelopersDeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CartEntity", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Domain.Entities.CartEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.GameEntity", b =>
                {
                    b.HasOne("Domain.Entities.CartEntity", null)
                        .WithMany("Games")
                        .HasForeignKey("CartEntityId");
                });

            modelBuilder.Entity("Domain.Entities.ImageEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", "Game")
                        .WithMany("Images")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.Entities.NotificationChannel", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany("NotificationChannels")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", "GameId")
                        .WithMany("ReviewId")
                        .HasForeignKey("GameIdId");

                    b.HasOne("Domain.Entities.ApplicationUser", "UserId")
                        .WithMany("Reviews")
                        .HasForeignKey("UserIdId");

                    b.Navigation("GameId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OrderEntity", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityPlatformEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PlatformEntity", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityPublisherEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PublisherEntity", null)
                        .WithMany()
                        .HasForeignKey("PublishersPublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("NotificationChannels");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.CartEntity", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Domain.Entities.GameEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ReviewId");
                });
#pragma warning restore 612, 618
        }
    }
}
