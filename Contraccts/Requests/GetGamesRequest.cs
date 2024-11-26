namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на получение списка игр для отображения
    /// </summary>
    public sealed class GetGamesRequest
    {
        /// <summary>
        /// Количество игр которые будут изображены
        /// </summary>
        public int Take {  get; set; }
        /// <summary>
        /// Количество игр которые будут пропущены
        /// </summary>
        public int Skip { get; set; }
        //===============Далее поля для фильтрации============
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
