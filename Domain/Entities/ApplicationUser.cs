using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    /// <summary>
    /// Сущность пользователя
    /// </summary>
    public class ApplicationUser : IdentityUser<int>
    {
        public long? TelegramChatId { get; set; }
        public ICollection<NotificationChannel> NotificationChannels { get; set; } = [];

        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Корзина
        /// </summary>
        public int CartId { get; set; } = 0;
        public CartEntity Cart { get; set; }
        /// <summary>
        /// Заказы
        /// </summary>
        public List<OrderEntity> Orders { get; set; } = [];
        /// <summary>
        /// Списко желаемых игр
        /// </summary>
        //public int Wishlistid { get; set; }
        //public WishlistEntity? Wishlist { get; set; }
        /// <summary>
        /// Отзывы написанные пользователем
        /// </summary>
        public List<ReviewEntity> Reviews { get; set; } = [];
        /// <summary>
        /// Баланс кошелька
        /// </summary>
        public decimal WalletBalance { get; set; } = 0;
    }
}
