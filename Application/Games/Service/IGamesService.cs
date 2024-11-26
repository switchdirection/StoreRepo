using Application.Games.Filters;
using Application.Games.Model;
using Contracts.Common;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Games
{
    /// <summary>
    /// Интерфейс сервиса по работе с играми
    /// </summary>
    public interface IGamesService
    {
        /// <summary>
        /// Метод для получения списка всех игр из бд
        /// </summary>
        Task<List<GameEntity>> GetAllAsync();

        /// <summary>
        /// Метод для получения всех "не удалённых" игры
        /// </summary>
        /// <param name="request">Запрос для пагинации</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<ShortGameEntityList> GetAllNotDeletedAsync(PagedRequest request, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения игры по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation);
        /// <summary>
        /// Получение параметров фильтрации
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<GameFilters> GetFilterOptionsAsync(CancellationToken cancellation);

        /// <summary>
        /// Метод добавления игры в бд
        /// </summary>
        /// <param name="game">Транспортная модель игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddGameAsync(ShortGameList game, CancellationToken cancellation);
        /// <summary>
        /// Метод для изменения опции isDeleted у игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task ChangeVisibilityAsync(int gameId, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteAsync(int gameId, CancellationToken cancellation);
        /// <summary>
        /// Метод для обновления игры
        /// </summary>
        /// <param name="model">Модель для редактирования игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> UpdateGameAsync(GameEditModel model, CancellationToken cancellation);
    }
}
