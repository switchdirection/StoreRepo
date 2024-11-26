namespace Domain.Entities
{
    /// <summary>
    /// История заказов
    /// </summary>
    public sealed class OrdersHistoryEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// ФИО пользователя совершивешго заказ
        /// </summary>
        public string FullUserName { get; set; }
        /// <summary>
        /// Тип оплаты
        /// </summary>
        public string PaymentType { get; set; } = "bankCard";
        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal OrderPrice { get; set; } = 0;
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; } = "В обработке";
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
