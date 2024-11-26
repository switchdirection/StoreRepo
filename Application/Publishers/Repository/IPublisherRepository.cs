using Application.Common;
using Application.Publishers.Model;
using Domain.Entities;

namespace Application.Publishers.Repository
{
    /// <summary>
    /// Интерфейс репозитория по работае с издателями
    /// </summary>
    public interface IPublisherRepository : IRepository<PublisherEntity>
    {
        /// <summary>
        /// Метод для получения издателей
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
        /// Метод для удаления издателя
        /// </summary>
        /// <param name="publisherId">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeletePublisherAsync(int publisherId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования издателя
        /// </summary>
        /// <param name="model">Модель для редактирования издателя</param>
        /// <param name="cancellation">Токен отмены</param>
        Task EditPublisherAsync(EditPublisherModel model, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления издателя
        /// </summary>
        /// <param name="entity">Издатель</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddPublisherByRequestAsync(PublisherEntity entity, CancellationToken cancellation);

    }
}
