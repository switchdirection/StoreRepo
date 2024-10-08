using System.ComponentModel;

namespace Domain.Entities
{
    /// <summary>
    /// Игра
    /// </summary>
    public sealed class GameEntity
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название игры
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Описание игры
        /// </summary>
        public string? Description { get; set; } = default!;
        /// <summary>
        /// Цена за единицу
        /// </summary>
        public double Price { get; set; } = 0;
        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime ReleaseDate { get; set; } = default!;
        /// <summary>
        /// Идентификатор разработчика
        /// </summary>
        public List<DeveloperEntity> Developers { get; set; } = new List<DeveloperEntity>();
        /// <summary>
        /// Идентификатор издателя
        /// </summary>
        public List<PublisherEntity> Publishers { get; set; } = new List<PublisherEntity>();
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
        /// <summary>
        /// Категории игры
        /// </summary>
        public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
        /// <summary>
        /// Платформы на которых игра будет доступна
        /// </summary>
        public List<PlatformEntity> Platforms { get; set; } = new List<PlatformEntity>();
        /// <summary>
        /// Список избранных игр
        /// </summary>
        public List<WishlistEntity> Wishlists { get; set; } = new List<WishlistEntity>();
        /// <summary>
        /// Отзывы на игру
        /// </summary>
        public List<ReviewEntity> ReviewId { get; set; } = new List<ReviewEntity>();
        /// <summary>
        /// Изображения игры
        /// </summary>
        public List<ImageEntity> Images { get; set; } = new List<ImageEntity>();
        /// <summary>
        /// Рейтинг игры
        /// </summary>
        public double Rating { get; set; } = 0;

    }
}
