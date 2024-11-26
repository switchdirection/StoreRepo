namespace Domain.Entities
{
    /// <summary>
    /// Платформа игры
    /// </summary>
    public sealed class PlatformEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PlatformId { get; set; }
        /// <summary>
        /// Название платформы
        /// </summary>
        public string? PlatformName { get; set; } = default!;
        /// <summary>
        /// Список игры для конкретной платформы
        /// </summary>
        public List<GameEntity> Games { get; set; } = new List<GameEntity>();
    }
}