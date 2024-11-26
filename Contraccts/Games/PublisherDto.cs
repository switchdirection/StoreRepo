namespace Contracts.Games
{
    /// <summary>
    /// Транспортная модель издателей
    /// </summary>
    public sealed class PublisherDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PublisherId { get; set; }
        /// <summary>
        /// Название издателя
        /// </summary>
        public string PublisherName { get; set; }
        /// <summary>
        /// Адрес сайта издателя
        /// </summary>
        public string WebsiteUrl { get; set; }
    }
}
