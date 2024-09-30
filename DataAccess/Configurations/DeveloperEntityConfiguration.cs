using Domain.Entities;
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
            //Идентификатор разработчика
            builder
                .HasKey(d => d.DeveloperId);
            //Связь многие ко многим, 1 разработчик может выпустить несколько игр, 1 игра может быть выпущена множеством разработчиков
            builder
                .HasMany(d => d.GameId)
                .WithMany(g => g.DeveloperId);
        }
    }
}
