using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация таблицы заказов
    /// </summary>
    public sealed class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Orders");

            //============Свойства=========
            //Идентификатор заказа
            builder
                .HasKey(o => o.OrderId);

            builder
                .Property(o => o.TotalPrice)
                .HasColumnName("totalorderprice")
                .IsRequired(true);

            builder
                .Property(o => o.Status)
                .HasColumnName("status")
                .IsRequired(true);

            builder
                .Property(o => o.PurchaseDate)
                .HasColumnName("purchasedate")
                .IsRequired(true);

            //============Связи=============
            //Связь 1 ко многим, 1 пользователь может иметь много заказов
            builder
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);
            //Связь многие ко многим, 1 заказ может включать множество игр, 1 игра может быть включена во множество заказов
            builder
                .HasMany(o => o.Games)
                .WithMany(g => g.Orders);
        }
    }
}
