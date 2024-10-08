namespace Domain.Entities
{
    /// <summary>
    /// Категории
    /// </summary>
    public sealed class CategoryEntity
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string? CategoryName { get; set; }
        /// <summary>
        /// Список игр
        /// </summary>
        public List<GameEntity> GameId { get; set; } = new List<GameEntity>();
    }
}