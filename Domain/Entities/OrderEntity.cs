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
        public int UserId { get; set; }
        /// <summary>
        /// Пользователя
        /// </summary>
        public ApplicationUser? User { get; set; }
        /// <summary>
        /// Цена заказа
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Список заказанных игр
        /// </summary>
        public List<GameEntity> Games { get; set; } = [];
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; } = "В обработке";
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime PurchaseDate { get; set; } = default!;
    }
}