using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы издателя
    /// </summary>
    public sealed class PublisherEntityConfiguration : IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder) 
        {
            //Имя таблицы
            builder.ToTable("Publisher");

            //==================Свойства================
            //Идентификатор издателя
            builder
                .HasKey(p => p.PublisherId);

            builder
                .Property(p => p.PublisherName)
                .HasColumnName("publishername")
                .IsRequired(true);

            builder
                .Property(p => p.WebsiteUrl)
                .HasColumnName("url")
                .IsRequired(false);

            //==================Связи===================
            //Связь многие ко многим, 1 издатель может выпустить много игр, и 1 игра может быть выпущена несколькими издателями
            builder
                .HasMany(p => p.Games)
                .WithMany(g => g.Publishers);

            //==============Данные===========
            builder
                .HasData(new PublisherEntity
                {
                    PublisherId = 1,
                    PublisherName = "Mojang Studios",
                    WebsiteUrl = "https://www.minecraft.net/en-us/article/meet-mojang-studios"
                },
                new PublisherEntity
                {
                    PublisherId = 2,
                    PublisherName = "Ubisoft Pune",
                    WebsiteUrl = "https://www.ubisoft.com/en-us/company/careers/locations/pune"
                },
                new PublisherEntity
                {
                    PublisherId = 3,
                    PublisherName = "Valve",
                    WebsiteUrl = "https://www.valvesoftware.com/ru/"
                });
        }
    }
}
