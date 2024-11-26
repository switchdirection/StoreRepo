using Application.Common;
using Application.Games.Model;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Games.Repositories
{
    /// <summary>
    /// Интерфейс репозитория по работе с играми
    /// </summary>
    public interface IGameRepository : IRepository<GameEntity>
    {
        /// <summary>
        /// Метод для получения всех игр
        /// </summary>
        Task<List<GameEntity>> GetAllGamesAsync();
        /// <summary>
        /// Метод для получения всех "не удалённых" игр
        /// </summary>
        /// <param name="request">Запрос на получения игр</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<GameEntity>> GetAllNotDeletedAsync(GetGamesRequest request, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения игры по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<GameEntity> GetElementByIdAsync(int id);
        /// <summary>
        /// Метод для изменения флага isDeleted у игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task ChangeVisibilityAsync(int gameId, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения игры по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteAsync(int gameId, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения количества игры
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<int> GetGamesTotalCountAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для обновления игры
        /// </summary>
        /// <param name="model">Модель редактирования игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task UpdateGameAsync(GameEditModel model, CancellationToken cancellation);
    }
}
