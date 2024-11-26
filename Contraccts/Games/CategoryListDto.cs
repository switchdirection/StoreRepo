namespace Contracts.Games
{
    /// <summary>
    /// Транспортная модель категорий
    /// </summary>
    public sealed class CategoryListDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
    }
}
