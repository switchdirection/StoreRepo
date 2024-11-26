namespace Contracts.Cart
{
    /// <summary>
    /// Транспортная модель элемента корзины
    /// </summary>
    public sealed class CartItemDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// Ссылка на основное изображение
        /// </summary>
        public string MainImageUrl { get; set; }
    }
}
