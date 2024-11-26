using Contracts.Games;

namespace Application.Games.Filters
{
    /// <summary>
    /// Класс для фильтрации списка игр
    /// </summary>
    public sealed class GameFilters
    {
        /// <summary>
        /// Категории
        /// </summary>
        public List<CategoryListDto> Categories { get; set; }
        /// <summary>
        /// Разработчики
        /// </summary>
        public List<DeveloperDto> Developers { get; set; }
        /// <summary>
        /// Издатели
        /// </summary>
        public List<PublisherDto> Publishers { get; set; }
        /// <summary>
        /// Платформы
        /// </summary>
        public List<PlatformDto> Platforms { get; set; }
    }
}
