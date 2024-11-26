using Domain.Entities;
using Contracts.Images;
using Microsoft.AspNetCore.Http;

namespace Application.Images.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с изображениями
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Метод для получения транспортной модели изображения
        /// </summary>
        /// <param name="id">Идентификатор изображения</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<ImageDto> GetImageDtoAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для сохранения изображения
        /// </summary>
        /// <param name="ImageFiles">Выбранное изображения</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IReadOnlyCollection<string>> SaveImagesAsync(List<IFormFile> ImageFiles, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления изображения к игре и сохранения
        /// </summary>
        /// <param name="mainImageUrl">Ссылка на главное изображени</param>
        /// <param name="imagesUrls">Остальные изображения</param>
        /// <param name="gameEntity">Игра</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task<ImageEntity[]> SaveImageEntityAsync(string mainImageUrl, string[] imagesUrls, GameEntity gameEntity, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления изображения
        /// </summary>
        /// <param name="imageId">Идентификатор изображения</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task DeleteImageAsync(int imageId, CancellationToken cancellation);
    }
}
