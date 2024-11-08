using Application.Common;
using Domain.Entities;

namespace Application.Games.Repositories
{
    public interface IGameRepository : IRepository<GameEntity>
    {
        Task<List<GameEntity>> GetAllGamesAsync();
        Task<GameEntity> GetElementById(int id);
        Task ChangeVisibility(int gameId, CancellationToken cancellation);
        Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation);
        Task DeleteAsync(int gameId, CancellationToken cancellation);
    }
}
