namespace Domain.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderEntity
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public UserEntity? UserId { get; set; }
        /// <summary>
        /// Цена заказа
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Список заказанных игр
        /// </summary>
        public GameEntity[]? GameId { get; set; } = [];
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; } = default!;
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime PurchaseDate { get; set;}
    }
}