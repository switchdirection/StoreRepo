namespace Domain.Entities
{
    /// <summary>
    /// Издатель
    /// </summary>
    public sealed class PublisherEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PublisherId { get; set; }
        /// <summary>
        /// Название издателя
        /// </summary>
        public string? PublisherName { get; set; }
        /// <summary>
        /// Ссылка на официальный сайт
        /// </summary>
        public string WebsiteUrl { get; set; } = default!;
        /// <summary>
        /// Игры выпущенные издателем
        /// </summary>
        public List<GameEntity> Games { get; set; } = new List<GameEntity>();
    }
}