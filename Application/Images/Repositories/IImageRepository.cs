using Application.Common;
using Domain.Entities;

namespace Application.Images.Repositories
{

    public interface IImageRepository : IRepository<ImageEntity>
    {
        /// <summary>
        /// Метод для получения изображения по сслыке
        /// </summary>
        /// <param name="url">Ссылка на изображение</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<ImageEntity> GetByUrlAsync(string url, CancellationToken cancellation);
        /// <summary>
        /// Методя для сохранения изображения
        /// </summary>
        /// <param name="image">Изображения</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns>Идентификатор сохраненнного изображения</returns>
        Task<int> SaveAsync(ImageEntity image, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления изображения
        /// </summary>
        /// <param name="imageId">Идентификатор изображения</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task DeleteImageAsync(int imageId, CancellationToken cancellation);
    }
}
