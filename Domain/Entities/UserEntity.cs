namespace Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public sealed class UserEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id{ get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string? PasswordHash { get; set; }
        /// <summary>
        /// Дата создания аккаунта
        /// </summary>
        public DateTime CreateAt { get; set; } = default(DateTime)!;
        /// <summary>
        /// Заказы
        /// </summary>
        public OrderEntity[]? Orders { get; set; } = [];
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string? Role { get; set; }
        /// <summary>
        /// Списко желаемых игр
        /// </summary>
        public int Wishlistid { get; set; }
        public WishlistEntity? Wishlist { get; set; }
        /// <summary>
        /// Отзывы написанные пользователем
        /// </summary>
        public ReviewEntity[]? ReviewId { get; set; } = [];
        /// <summary>
        /// Баланс кошелька
        /// </summary>
        public decimal WalletBalance { get; set; } = 0;
    }
}
