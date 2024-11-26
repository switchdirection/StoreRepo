namespace Application.Orders.Model
{
    /// <summary>
    /// Модель для отображения заказа
    /// </summary>
    public sealed class OrderViewModel
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Количество продуктов
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; }
    }

}

