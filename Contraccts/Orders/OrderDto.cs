namespace Contracts.Orders
{
    /// <summary>
    /// Транспортная модель заказа
    /// </summary>
    public sealed class OrderDto
    {
        // <summary>
        /// Идентификатор 
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Цена заказа
        /// </summary>
        public decimal TotalPrice { get; set; }
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
