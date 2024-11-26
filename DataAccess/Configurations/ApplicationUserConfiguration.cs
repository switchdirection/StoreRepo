using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Configurations
{
    public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //==============Связи=================
            //связь 1 к 1, 1 пользователь имеет 1 карзину
            builder
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<CartEntity>(c => c.UserId);
;
            //Связь 1 ко многим, 1 пользователь может иметь много заказов
            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);
            //Связь 1 к 1, 1 пользователь имеет 1 список желаемых игр
            /*builder
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.User)
                .HasForeignKey<WishlistEntity>(w => w.UserId);*/

            builder
                .HasMany(u => u.Reviews)
                .WithOne(review => review.UserId);
        }
    }
}
