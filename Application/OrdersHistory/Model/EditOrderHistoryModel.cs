namespace Application.OrdersHistory.Model
{
    /// <summary>
    /// Модель редактирования истории заказа
    /// </summary>
    public sealed class EditOrderHistoryModel
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }  
        /// <summary>
        /// ФИО покупателя
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Тип оплаты
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public string Status { get; set; }
    }
}
