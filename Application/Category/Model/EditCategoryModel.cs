namespace Application.Category.Model
{
    /// <summary>
    /// Модель для редактирования категории
    /// </summary>
    public sealed class EditCategoryModel
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
    }
}
