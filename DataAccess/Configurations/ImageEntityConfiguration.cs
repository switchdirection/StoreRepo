using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы изображений
    /// </summary>
    public sealed class ImageEntityConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Images");

            //==========Свойства=======
            //Идентификатор изображения
            builder
                .HasKey(i => i.ImageId);

            builder
                .Property(i => i.ImageUrl)
                .HasColumnName("imageurl")
                .IsRequired(true);

            //===========Связи==========
            //Связь 1 ко многим, 1 игра может быть множество изображений
            builder
                .HasOne(i => i.GameId)
                .WithMany(g => g.Images);
        }
    }
}
