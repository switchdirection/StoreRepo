using Application.Common;
using Domain.Entities;

namespace Application.Games
{
    /// <summary>
    /// Интерфейс
    /// </summary>
    public interface IGamesService
    {
        Task<List<GameEntity>> GetAllAsync();
    }
}
