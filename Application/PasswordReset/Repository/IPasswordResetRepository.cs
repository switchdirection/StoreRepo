using Application.Common;
using Contracts.Requests;
using Domain.Entities;

namespace Application.PasswordReset.Repository
{
    /// <summary>
    /// Интерфейс репозитория для сброса пароля
    /// </summary>
    public interface IPasswordResetRepository : IRepository<PasswordResetEntity>
    {
        /// <summary>
        /// Метод для добавления запроса для сброса пароля
        /// </summary>
        /// <param name="entity">Сущность запроса на сброс</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddPasswordResetRequestAsync(PasswordResetEntity entity, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения запроса
        /// </summary>
        /// <param name="resetCode">Код для сброса пароля</param>
        Task<PasswordResetEntity> GetRequestAsync(string resetCode);
        /// <summary>
        /// Метод для удаления запроса на удаления пароля
        /// </summary>
        /// <param name="request">Запрос на сброс пароля</param>
        /// <param name="cancellation">Токен отмены</param>
        Task RemovePasswordResetRequestAsync(PasswordResetRequest request, CancellationToken cancellation);
    }
}
