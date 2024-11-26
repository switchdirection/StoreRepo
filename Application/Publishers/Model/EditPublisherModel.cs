namespace Application.Publishers.Model
{
    /// <summary>
    /// Модель для редактирования издателя
    /// </summary>
    public sealed class EditPublisherModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PublisherId { get; set; }
        /// <summary>
        /// Название издателя
        /// </summary>
        public string PublisherName { get; set;}
        /// <summary>
        /// Адрес сайта издателя
        /// </summary>
        public string PublisherUrl { get; set; } = "Не указан";
    }
}
