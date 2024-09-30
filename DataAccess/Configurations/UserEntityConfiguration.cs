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
            //Имя таблицы
            builder.ToTable("Users");

            //==============Свойства==============
            //Идентификатор пользователя
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.UserName)
                .HasColumnName("username")
                .IsRequired(true);

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired(true);

            builder
                .Property(u => u.PasswordHash)
                .HasColumnName("password")
                .IsRequired(true);

            builder
                .Property(u => u.CreateAt)
                .HasColumnName("createat")
                .IsRequired(true);
            builder
                .Property(u => u.Role)
                .HasColumnName("role")
                .IsRequired(true);

            //==============Связи=================
            //Связь 1 ко многим, 1 пользователь может иметь много заказов
            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.UserId);
            //Связь 1 к 1, 1 пользователь имеет 1 список желаемых игр
            builder
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.User).HasForeignKey<WishlistEntity>(w => w.UserId);
        }
    }
}
