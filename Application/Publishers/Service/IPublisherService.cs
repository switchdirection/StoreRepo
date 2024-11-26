using Application.Publishers.Model;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Publishers.Service
{
    /// <summary>
    /// Интерфейс сервиса по работе с издателями
    /// </summary>
    public interface IPublisherService
    {
        /// <summary>
        /// Метод для получения всех издателей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<PublisherEntity>> GetAllPublishersAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для получения издателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<PublisherEntity> GetPublisherByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения всех издателей в виде транспортной модели
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
		Task<List<PublisherDto>> GetAllPublishersDtoAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления издателя
        /// </summary>
        /// <param name="publisherId">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeletePublisherAsync(int publisherId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования издателя
        /// </summary>
        /// <param name="model">Модель для редактирования</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> EditPublisherAsync(EditPublisherModel model, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления издателя по запросу
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddPublisherByRequestAsync(AddPublisherRequest request, CancellationToken cancellation);

    }
}
