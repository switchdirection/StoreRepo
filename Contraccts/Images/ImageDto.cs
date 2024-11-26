namespace Contracts.Images
{
    /// <summary>
    /// Транспортная модель изображения
    /// </summary>
    public sealed class ImageDto
    {
        /// <summary>
        /// Изображения в виде потока байтов
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// Тип контента изображения
        /// </summary>
        public string ContentType { get; set; }
    }
}
