using Application.Common;
using Contracts.Games;
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
        /// Метод добавления игры в бд
        /// </summary>
        /// <param name="game">Транспортная модель игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddGameAsync(ShortGameList game, CancellationToken cancellation);
    }
}
