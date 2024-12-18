﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы разработчиков
    /// </summary>
    public sealed class DeveloperEntityConfiguration : IEntityTypeConfiguration<DeveloperEntity>
    {
        public void Configure(EntityTypeBuilder<DeveloperEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Developers");

            //===============Свойства================
            //Идентификатор разработчика
            builder
                .HasKey(d => d.DeveloperId);

            builder
                .Property(d => d.DeveloperName)
                .HasColumnName("developername")
                .IsRequired(true);

            builder
                .Property(d => d.WebsiteUrl)
                .HasColumnName("url")
                .IsRequired(false);

            //================Связи===================
            //Связь многие ко многим, 1 разработчик может выпустить несколько игр, 1 игра может быть выпущена множеством разработчиков
            builder
                .HasMany(d => d.Games)
                .WithMany(g => g.Developers);


            //===================Данные=============
            builder
                .HasData(new DeveloperEntity
                {
                    DeveloperId = 1,
                    DeveloperName = "Ubisoft",
                    WebsiteUrl = "https://www.ubisoft.com/ru-ru/"
                },
                new DeveloperEntity
                {
                    DeveloperId = 2,
                    DeveloperName = "Electronic Arts",
                    WebsiteUrl = "https://www.ea.com/ru-ru"
                },
                new DeveloperEntity
                {
                    DeveloperId = 3,
                    DeveloperName = "Activision Blizzard",
                    WebsiteUrl = "https://www.activisionblizzard.com/"
                });
        }
    }
}
