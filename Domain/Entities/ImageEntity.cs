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
        /// Ссылка на изображение
        /// </summary>
        public string ImageUrl { get; set; } = default!;
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public GameEntity? GameId { get; set; }
    }
}