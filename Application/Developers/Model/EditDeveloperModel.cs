namespace Application.Developers.Model
{
    /// <summary>
    /// Модель для редактирования разработчика
    /// </summary>
    public sealed class EditDeveloperModel
    {
        /// <summary>
        /// Идентификатор разработчика
        /// </summary>
        public int DeveloperId { get; set; }
        /// <summary>
        /// Имя разработчика
        /// </summary>
        public string DeveloperName { get; set; }
        /// <summary>
        /// Адрес веб-сайта разработчика (если есть)
        /// </summary>
        public string DeveloperUrl { get; set; } = "Не указан";
    }
}
