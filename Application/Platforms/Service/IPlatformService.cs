using Application.Platforms.Model;
using Contracts.Games;
using Domain.Entities;

namespace Application.Platforms.Service
{
    /// <summary>
    /// Интерфейс сервиса по работе с платформами
    /// </summary>
    public interface IPlatformService
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
        /// Метод для получения всех платформ в виде транспортной модели
        /// </summary>
        /// <param name="cancellation"></param>
        Task<List<PlatformDto>> GetAllPlatformsDtoAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления платформы
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeletePlatformAsync(int platformId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования платформы
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
