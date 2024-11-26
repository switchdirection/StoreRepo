namespace Contracts.Orders
{
    /// <summary>
    /// Транспортная модель истории заказа
    /// </summary>
    public sealed class OrdersHistoryDto
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
        public string PaymentType { get; set; }
        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
