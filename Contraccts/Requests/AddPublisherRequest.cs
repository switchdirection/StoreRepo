
namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавление издателя
    /// </summary>
    public sealed class AddPublisherRequest
    {
        /// <summary>
        /// Название издателя
        /// </summary>
        public string PublisherName { get; set; }
        /// <summary>
        /// Адрес веб-сайта издателя
        /// </summary>
        public string PublisherWebsite { get; set; }
    }
}
