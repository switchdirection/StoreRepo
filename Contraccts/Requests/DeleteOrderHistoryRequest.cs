namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавление истории заказа
    /// </summary>
    public sealed class DeleteOrderHistoryRequest
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
    }
}
