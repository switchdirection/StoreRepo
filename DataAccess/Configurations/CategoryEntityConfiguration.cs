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
            //Идентификатор категории
            builder
                .HasKey(c => c.CategoryId);
            //Связь многие ко многим, 1 игра может иметь множество категорий, 1 категория может подходить под множество игр
            builder
                .HasMany(c => c.GameId)
                .WithMany(g => g.CategoryId);
        }
    }
}
