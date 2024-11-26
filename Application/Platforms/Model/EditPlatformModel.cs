namespace Application.Platforms.Model
{
    /// <summary>
    /// Модель для редактирования платформ
    /// </summary>
    public sealed class EditPlatformModel
    {
        /// <summary>
        /// Идентификатор платформы
        /// </summary>
        public int PlatformId { get; set; }
        /// <summary>
        /// Название платформы
        /// </summary>
        public string PlatformName { get; set; }
    }
}
