namespace Domain.Entities
{
    /// <summary>
    /// Разработчик
    /// </summary>
    public sealed class DeveloperEntity
    {
        /// <summary>
        /// Идентификатор разработчика
        /// </summary>
        public int DeveloperId { get; set; }
        /// <summary>
        /// Наименование компании
        /// </summary>
        public string? DeveloperName { get; set; } = default!;
        /// <summary>
        /// Ссылка на официальный сайт
        /// </summary>
        public string WebsiteUrl { get; set; } = default!;
        /// <summary>
        /// Игры выпущенные этим разработчиком
        /// </summary>
        public GameEntity[]? GameId { get; set; }
    }
}