using Contracts.Games;

namespace Application.Games.Model
{
    /// <summary>
    /// Модель для редактирования игры
    /// </summary>
    public sealed class GameEditModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название игры
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Количество в наличии
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Рейтинг
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Удалена ли игра
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Идентификаторы категорий которые выбраны
        /// </summary>
        public List<int> SelectedCategoryIds { get; set; } = new();
        /// <summary>
        /// Идентификаторы разработчиков который выбраны
        /// </summary>
        public List<int> SelectedDeveloperIds { get; set; } = new();
        /// <summary>
        /// Идентификаторы издателей которые выбраны
        /// </summary>
        public List<int> SelectedPublisherIds { get; set; } = new();
        /// <summary>
        /// Идентификаторы платформ которые выбраны
        /// </summary>
        public List<int> SelectedPlatformIds { get; set; } = new();

        /// <summary>
        /// Все категории
        /// </summary>
        public List<CategoryListDto> AllCategories { get; set; } = new();
        /// <summary>
        /// Все разработчики
        /// </summary>
        public List<DeveloperDto> AllDevelopers { get; set; } = new();
        /// <summary>
        /// Все издатели
        /// </summary>
        public List<PublisherDto> AllPublishers { get; set; } = new();
        /// <summary>
        /// Все платформы
        /// </summary>
        public List<PlatformDto> AllPlatforms { get; set; } = new();
    }
}
