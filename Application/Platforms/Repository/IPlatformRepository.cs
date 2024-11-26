using Application.Common;
using Application.Platforms.Model;
using Domain.Entities;

namespace Application.Platforms.Repository
{
    /// <summary>
    /// Сервис репозитория по работе с платформами
    /// </summary>
    public interface IPlatformRepository : IRepository<PlatformEntity>
    {
        /// <summary>
        /// Метод для получения всех платформ
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<PlatformEntity>> GetAllPlatformsAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для получения платформы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<PlatformEntity> GeetPlatformByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Методя для удаления платформы
        /// </summary>
        /// <param name="platformId">Илентификатор платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeletePlatformAsync(int platformId, CancellationToken cancellation);
        /// <summary>
        /// Методя для редактирования платформы
        /// </summary>
        /// <param name="model">Модель для редактирования платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> EditPlatformAsync(EditPlatformModel model, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления платформы
        /// </summary>
        /// <param name="platformName">Название платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddPlatformAsync(string platformName, CancellationToken cancellation);
    }
}
