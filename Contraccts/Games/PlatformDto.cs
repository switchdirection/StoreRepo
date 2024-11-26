namespace Contracts.Games
{
    /// <summary>
    /// Транспортная модель платформ
    /// </summary>
    public sealed class PlatformDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PlatformId { get; set; }
        /// <summary>
        /// Название платформы
        /// </summary>
        public string PlatformName { get; set; }
    }
}
