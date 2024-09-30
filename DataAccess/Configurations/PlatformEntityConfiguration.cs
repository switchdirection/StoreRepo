using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы платформ
    /// </summary>
    public sealed class PlatformEntityConfiguration : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Platform");

            //===============Свойства================
            //Идентификатор платформы
            builder
                .HasKey(p => p.PlatformId);

            builder
                .Property(p => p.PlatformName)
                .HasColumnName("platformname")
                .IsRequired(true);

            //==============Связи====================
            //Связь многие ко многим, 1 игра может быть выпущена на несколько платформ, 1 платформа может быть подходящей для множества игр
            builder
                .HasMany(p => p.GameId)
                .WithMany(g => g.PlatformId);
        }
    }
}
