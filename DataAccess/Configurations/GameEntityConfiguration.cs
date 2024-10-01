using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы игр
    /// </summary>
    public sealed class GameEntityConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Games");

            //=============Свойства============
            //Идентификатор игры
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Title)
                .HasColumnName("title")
                .IsRequired(true);

            builder
                .Property(g => g.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder
                .Property(g => g.Price)
                .HasColumnName("price")
                .IsRequired(true);

            builder
                .Property(g => g.ReleaseDate)
                .HasColumnName("releasedate")
                .IsRequired(true);

            builder
                .Property(g => g.Rating)
                .HasColumnName("rating")
                .IsRequired(true);

            //==============Связи==============
            //Связь многие ко многим, 1 разработчик может выпустить несколько игр, 1 игра может быть выпущена несколькими разработчиками
            builder
                .HasMany(g => g.DeveloperId)
                .WithMany(d => d.GameId);
            //Свзяь многие ко многим, 1 издатель может выпустить несколько игр, 1 игра может быть выпущена несколькими издателями
            builder
                .HasMany(g => g.PublisherId)
                .WithMany(p => p.GameId);
            //Свзяь многие ко многим, 1 заказ может включать несколько игр, 1 игра может быть включена во множество заказов
            builder
                .HasMany(g => g.OrderId)
                .WithMany(o => o.GameId);
            //Связь многие ко многим, 1 игра может иметь несколько категорий, 1 категория может подходить под множество игр
            builder
                .HasMany(g => g.CategoryId)
                .WithMany(c => c.GameId);
            //Связь многие ко многим, 1 платформа может подходить под множество игр, 1 игра может подходить под множество платформ
            builder
                .HasMany(g => g.PlatformId)
                .WithMany(p => p.GameId);
            //Связь многие ко многим, 1 игра может находиться во множетсве списков желаемого, 1 список желаемых игр может включать множество игр
            builder
                .HasMany(g => g.WishlistId)
                .WithMany(w => w.GameId);
            //Связь 1 ко многим, 1 игра может включать множество картинок 
            builder
                .HasMany(g => g.Images)
                .WithOne(i => i.GameId);


            //=================Данные================
            builder
                .HasData(new GameEntity
                {
                    Id = 1,
                    Title = "Need For Speed",
                    Description = "Прикольные гоночки",
                    Price = 14.99,
                    ReleaseDate = DateTime.UtcNow.AddDays(25),
                    Rating = 5
                },
                new GameEntity
                {
                    Id = 2,
                    Title = "Assasin Creed",
                    Description = "Что-то про мужика который прыгает по крышам",
                    Price = 59.99,
                    ReleaseDate = DateTime.UtcNow.AddDays(20),
                    Rating = 4.7
                },
                new GameEntity
                {
                    Id = 3,
                    Title = "Call Of Duty",
                    Description = "Что-то про мужиков которые стреляют",
                    Price = 14.99,
                    ReleaseDate = DateTime.UtcNow.AddDays(11),
                    Rating = 4.9
                });
        }
    }
}
