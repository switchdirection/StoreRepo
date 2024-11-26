namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавления игры в корзину
    /// </summary>
    public class AddToCartRequest
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public int GameId { get; set; }
    }
}
