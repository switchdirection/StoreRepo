namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавление категории
    /// </summary>
    public sealed class AddCategoryRequest
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string categoryName { get; set; }
    }
}
