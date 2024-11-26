namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавление заказа
    /// </summary>
    public sealed class AddOrderRequest
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string userLastname { get; set; }
        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string userSurname { get; set; }
        /// <summary>
        /// Тип оплаты
        /// </summary>
        public string paymentType { get; set; }
        /// <summary>
        /// Номер карты
        /// </summary>
        public string cardNumber { get; set; }
        /// <summary>
        /// Срок действия карты
        /// </summary>
        public string cardExpiry { get; set; }
        /// <summary>
        /// CVC код карты
        /// </summary>
        public string cardCvc { get; set; }
        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal totalPrice { get; set; }
    }
}
