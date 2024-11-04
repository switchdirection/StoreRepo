using Application.Games.Repositories;
using Application.Images.Handler;
using Application.Images.Repositories;
using Application.Images.Services;
using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Application.Games
{
    public sealed class GameService : IGamesService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public GameService(
            IGameRepository gameRepository,
            IMapper mapper,
            IImageService imageService
        )
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task AddGameAsync(ShortGameList game, CancellationToken cancellation)
        {
            var domainGame = _mapper.Map<GameEntity>(game);
            
            domainGame.Images = await _imageService.SaveImageEntityAsync(game.ImagesUrls, domainGame, cancellation);
            domainGame.ReleaseDate = DateTime.UtcNow;

            await _gameRepository.AddAsync(domainGame);
        }

        public Task<List<GameEntity>> GetAllAsync()
        {
            var result =  _gameRepository.GetAllGamesAsync();
            return result;
        }
    }
}
