using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы отзывов
    /// </summary>
    public sealed class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Review");

            //============Свойства===========
            //Идентификатор отзыва
            builder
                .HasKey(r => r.ReviewId);

            builder
                .Property(r => r.Rating)
                .HasColumnName("rating")
                .IsRequired(true);

            builder
                .Property(r => r.ReviewText)
                .HasColumnName("reviewtext")
                .IsRequired(true);

            builder
                .Property(r => r.ReviewDate)
                .HasColumnName("reviewdate")
                .IsRequired(true);

            //============Связи==============
            //Связь 1 ко многим, 1 пользователь может иметь много написанных отзывов
            builder
                .HasOne(r => r.UserId)
                .WithMany(u => u.Reviews);
            //Связь 1 ко многим, 1 игра может иметь много отзывов
            builder
                .HasOne(r => r.GameId)
                .WithMany(g => g.ReviewId);
        }
    }
}
