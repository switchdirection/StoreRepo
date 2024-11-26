namespace Contracts.Requests
{
    /// <summary>
    /// Запрос на добавление платформы
    /// </summary>
    public sealed class AddPlatformRequest
    {
        /// <summary>
        /// Название платформы
        /// </summary>
        public string platformName { get; set; }
    }
}
