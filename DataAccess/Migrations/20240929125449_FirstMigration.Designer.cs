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
    [Migration("20240929125449_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryEntityGameEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.HasKey("CategoryId", "GameIdId");

                    b.HasIndex("GameIdId");

                    b.ToTable("CategoryEntityGameEntity");
                });

            modelBuilder.Entity("DeveloperEntityGameEntity", b =>
                {
                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer");

                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.HasKey("DeveloperId", "GameIdId");

                    b.HasIndex("GameIdId");

                    b.ToTable("DeveloperEntityGameEntity");
                });

            modelBuilder.Entity("Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoryes");
                });

            modelBuilder.Entity("Domain.Entities.DeveloperEntity", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeveloperId"));

                    b.Property<string>("DeveloperName")
                        .HasColumnType("text");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Domain.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.Entities.ImageEntity", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<int?>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ImageId");

                    b.HasIndex("GameIdId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("UserIdId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("UserIdId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.PlatformEntity", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlatformId"));

                    b.Property<string>("PlatformName")
                        .HasColumnType("text");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Domain.Entities.PublisherEntity", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .HasColumnType("text");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
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
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReviewText")
                        .HasColumnType("text");

                    b.Property<int?>("UserIdId")
                        .HasColumnType("integer");

                    b.HasKey("ReviewId");

                    b.HasIndex("GameIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<decimal>("WalletBalance")
                        .HasColumnType("numeric");

                    b.Property<int>("Wishlistid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Wishlistid")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.WishlistEntity", b =>
                {
                    b.Property<int>("WishlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WishlistId"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("WishlistId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("GameIdId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("GameEntityOrderEntity");
                });

            modelBuilder.Entity("GameEntityPlatformEntity", b =>
                {
                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.HasKey("GameIdId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GameEntityPlatformEntity");
                });

            modelBuilder.Entity("GameEntityPublisherEntity", b =>
                {
                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer");

                    b.HasKey("GameIdId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("GameEntityPublisherEntity");
                });

            modelBuilder.Entity("GameEntityWishlistEntity", b =>
                {
                    b.Property<int>("GameIdId")
                        .HasColumnType("integer");

                    b.Property<int>("WishlistId")
                        .HasColumnType("integer");

                    b.HasKey("GameIdId", "WishlistId");

                    b.HasIndex("WishlistId");

                    b.ToTable("GameEntityWishlistEntity");
                });

            modelBuilder.Entity("CategoryEntityGameEntity", b =>
                {
                    b.HasOne("Domain.Entities.CategoryEntity", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
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
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ImageEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", "GameId")
                        .WithMany("Images")
                        .HasForeignKey("GameIdId");

                    b.Navigation("GameId");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "UserId")
                        .WithMany("Orders")
                        .HasForeignKey("UserIdId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("Domain.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", "GameId")
                        .WithMany("ReviewId")
                        .HasForeignKey("GameIdId");

                    b.HasOne("Domain.Entities.UserEntity", "UserId")
                        .WithMany("ReviewId")
                        .HasForeignKey("UserIdId");

                    b.Navigation("GameId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.WishlistEntity", "Wishlist")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.UserEntity", "Wishlistid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OrderEntity", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityPlatformEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PlatformEntity", null)
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityPublisherEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PublisherEntity", null)
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameEntityWishlistEntity", b =>
                {
                    b.HasOne("Domain.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GameIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WishlistEntity", null)
                        .WithMany()
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.GameEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ReviewId");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ReviewId");
                });

            modelBuilder.Entity("Domain.Entities.WishlistEntity", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
