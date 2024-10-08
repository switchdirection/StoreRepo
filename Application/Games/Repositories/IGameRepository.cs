using Application.Common;
using Domain.Entities;

namespace Application.Games.Repositories
{
    public interface IGameRepository : IRepository<GameEntity>
    {
        Task<List<GameEntity>> GetAllGamesAsync();
        Task<GameEntity> GetElementById(int id);
    }
}
