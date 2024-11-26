namespace Domain.Entities
{
    /// <summary>
    /// Фотографии игры
    /// </summary>
    public sealed class ImageEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
        /// <summary>
        /// Контент изображения.
        /// </summary>
        public byte[] Content { get; set; } = default!;

        /// <summary>
        /// Тип контента.
        /// </summary>
        public string? ContentType { get; set; } = default!;

        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public int? GameId { get; set; }
        /// <summary>
        /// Игра
        /// </summary>
        public GameEntity? Game { get; set; }
    }
}
