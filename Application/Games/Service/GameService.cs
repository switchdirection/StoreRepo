using Application.Games.Repositories;
using Domain.Entities;

namespace Application.Games
{
    public sealed class GameService : IGamesService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameEntity>> GetAllAsync()
        {
            var result = await _gameRepository.GetAllGamesAsync();
            return result;
        }
    }
}
