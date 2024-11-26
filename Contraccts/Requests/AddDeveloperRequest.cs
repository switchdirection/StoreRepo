namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на доавбление разработчика
    /// </summary>
    public sealed class AddDeveloperRequest
    {
        /// <summary>
        /// Название разработчика
        /// </summary>
        public string DeveloperName { get; set; }
        /// <summary>
        /// Адрес вебсайта разработчика
        /// </summary>
        public string DeveloperWebsite { get; set; }
    }
}
