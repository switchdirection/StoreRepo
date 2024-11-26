using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public sealed class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            //Имя таблицы
            builder.ToTable("Carts");


            //====================Свойства=====================
            builder
               .HasKey(c => c.Id);


            builder
                .Property(c => c.UserId)
                .HasColumnName("userid")
                .IsRequired(true);

            //====================Связи========================
            //Связь 1 к 1, 1 корзина имеет 1 пользователя
        }
    }
}
