using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы категорий
    /// </summary>
    public sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Categories");

            //===============Свойства================
            //Идентификатор категории
            builder
                .HasKey(c => c.CategoryId);

            
            builder
                .Property(c => c.CategoryName)
                .HasColumnName("categoryname")
                .IsRequired(true);

            //================Связи===================
            //Связь многие ко многим, 1 игра может иметь множество категорий, 1 категория может подходить под множество игр
            builder
                .HasMany(c => c.GameId)
                .WithMany(g => g.CategoryId);

            //=======================Данные======================
            builder
                .HasData(new CategoryEntity
                {
                    CategoryId = 1,
                    CategoryName = "RPG"
                },
                new CategoryEntity
                {
                    CategoryId = 2,
                    CategoryName = "Action RPG"
                },
                new CategoryEntity
                {
                    CategoryId = 3,
                    CategoryName = "Rougelike"
                });
        }
    }
}
