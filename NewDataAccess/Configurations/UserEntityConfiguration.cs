using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация пользователя
    /// </summary>
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //Идентификатор пользователя
            builder
                .HasKey(u => u.Id);
            //Связь 1 ко многим, 1 пользователь может иметь много заказов
            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.UserId);
            //Связь 1 к 1, 1 пользователь имеет 1 список желаемых игр
            builder
                .HasOne(u => u.Wishlistid)
                .WithOne(w => w.UserId);
        }
    }
}
