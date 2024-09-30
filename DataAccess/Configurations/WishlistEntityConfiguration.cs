using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация списка желаемых игр
    /// </summary>
    public sealed class WishlistEntityConfiguration : IEntityTypeConfiguration<WishlistEntity>
    {
        
        public void Configure(EntityTypeBuilder<WishlistEntity> builder) 
        {
            //Имя таблицы
            builder.ToTable("Wishlist");

            //==============Свойства============
            //Идентификатор
            builder
                .HasKey(w => w.WishlistId);

            //==============Связи===============
            //Связь один ко многим, один пользователь - много желаемых игр
            builder
                .HasOne(w => w.User)
                .WithOne(u => u.Wishlist)
                .HasForeignKey<UserEntity>(u => u.Wishlistid);
            //Связь многие ко многим, разные списки могут содержать 1 игру, и наоборот
            builder
                .HasMany(w => w.GameId)
                .WithMany(g => g.WishlistId);
        }
    }
}
