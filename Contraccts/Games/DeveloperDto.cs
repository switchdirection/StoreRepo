namespace Contracts.Games
{
    /// <summary>
    /// Транспортная модель разработчиков
    /// </summary>
    public sealed class DeveloperDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int DeveloperId { get; set; }
        /// <summary>
        /// Название разработчика
        /// </summary>
        public string DeveloperName { get; set; }
        /// <summary>
        /// Адрес сайта разработчика
        /// </summary>
        public string WebsiteUrl { get; set; }
    }
}
