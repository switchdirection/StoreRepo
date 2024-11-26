using Contracts.Games;

namespace Contracts.Common
{
    /// <summary>
    /// запрос на пагинацию
    /// </summary>
    /// <typeparam name="T">Класс элементов которые будут пагинироваться</typeparam>
    public class PagedResponse<T>
    {
        /// <summary>
        /// Количество всего
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Количесто элементов на странице
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Список категорий
        /// </summary>
        public List<CategoryListDto> Categories { get; set; }
        /// <summary>
        /// Список разработчиков
        /// </summary>
        public List<DeveloperDto> Developers { get; set; }
        /// <summary>
        /// Список издателей
        /// </summary>
        public List<PublisherDto> Publishers { get; set; }
        /// <summary>
        /// Список платформ
        /// </summary>
        public List<PlatformDto> Platforms { get; set; }
        /// <summary>
        /// Элементы пагинации
        /// </summary>
        public List<T> Result { get; set; } = [];
    }
}
