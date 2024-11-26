namespace Contracts.Requests
{
    /// <summary>
    /// Запрос для отображения страницы
    /// </summary>
    public sealed class PagedRequest
    {
        /// <summary>
        /// Количестов элементов на странице
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        //========================Далее поля для фильтрации================================
        /// <summary>
        /// Поле поиска если оно было использовано
        /// </summary>
        public string? Search { get; set; }
        /// <summary>
        /// Выбранные категории
        /// </summary>
        public int[]? Categories { get; set; }
        /// <summary>
        /// Минимальный предел цены
        /// </summary>
        public int? MinPrice { get; set; }
        /// <summary>
        /// Максимальный предел цены
        /// </summary>
        public int? MaxPrice { get; set; }
        /// <summary>
        /// Выбранные разработчики
        /// </summary>
        public int[]? Developers { get; set; }
        /// <summary>
        /// Выбранные платформы
        /// </summary>
        public int[]? Platforms { get; set; }
        /// <summary>
        /// Выбранные издатели
        /// </summary>
        public int[]? Publishers { get; set; }
    }
}
