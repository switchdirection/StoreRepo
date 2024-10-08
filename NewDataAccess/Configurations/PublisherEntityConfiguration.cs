﻿using Domain.Entities;
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
            //Идентификатор издателя
            builder
                .HasKey(p => p.PublisherId);
            //Связь многие ко многим, 1 издатель может выпустить много игр, и 1 игра может быть выпущена несколькими издателями
            builder
                .HasMany(p => p.GameId)
                .WithMany(g => g.PublisherId);
        }
    }
}
