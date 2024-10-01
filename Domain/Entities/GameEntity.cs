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
        public DeveloperEntity[]? DeveloperId { get; set; } = [];
        /// <summary>
        /// Идентификатор издателя
        /// </summary>
        public PublisherEntity[]? PublisherId { get; set; } = [];
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public OrderEntity[]? OrderId { get; set; } = [];
        /// <summary>
        /// Категории игры
        /// </summary>
        public CategoryEntity[]? CategoryId { get; set; } = [];
        /// <summary>
        /// Платформы на которых игра будет доступна
        /// </summary>
        public PlatformEntity[]? PlatformId { get; set; } = [];
        /// <summary>
        /// Список избранных игр
        /// </summary>
        public WishlistEntity[]? WishlistId { get; set; } = [];
        /// <summary>
        /// Отзывы на игру
        /// </summary>
        public ReviewEntity[]? ReviewId { get; set; } = [];
        /// <summary>
        /// Изображения игры
        /// </summary>
        public ImageEntity[]? Images { get; set; } = [];
        /// <summary>
        /// Рейтинг игры
        /// </summary>
        public double Rating { get; set; } = 0;

    }
}
