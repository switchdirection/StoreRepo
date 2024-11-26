namespace Contracts.Games
{
    /// <summary>
    /// Краткое информация о игре
    /// </summary>
    public sealed class ShortGameList
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Количество игр в наличии
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Главное изображение
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Разработчики
        /// </summary>
        public List<DeveloperDto> Developers { get; set; } = [];
        /// <summary>
        /// Издатели
        /// </summary>
        public List<PublisherDto> Publishers { get; set; } = [];
        /// <summary>
        /// Платформы
        /// </summary>
        public List<PlatformDto> Platforms { get; set; } = [];

        /// <summary>
        /// Остальные изображения
        /// </summary>
        public string[] ImagesUrls { get; set; } = [];
        /// <summary>
        /// Категории
        /// </summary>

        public List<CategoryListDto> Categories { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Удалена ли игра или нет
        /// </summary>
        public bool IsDeleted { get; set; } 
    }
}
