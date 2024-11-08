using Application.Category.Services;
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
        private readonly ICategoryService _categoryService;
        public GameService(
            IGameRepository gameRepository,
            IMapper mapper,
            IImageService imageService,
            ICategoryService categoryService
        )
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        public async Task AddGameAsync(ShortGameList game, CancellationToken cancellation)
        {
            var categories = new List<CategoryEntity>(game.Categories.Count);
            foreach (var category in game.Categories)
            {
                categories.Add(await _categoryService.GetCategoryById(int.Parse(category.CategoryId))); 
            }
            game.Categories = null;

            var domainGame = _mapper.Map<GameEntity>(game);
            
            foreach(var category in categories)
            {
                domainGame.Categories.Add(category);
            }

            domainGame.Images = await _imageService.SaveImageEntityAsync(game.ImageUrl, game.ImagesUrls, domainGame, cancellation);
            domainGame.ReleaseDate = DateTime.UtcNow;

            await _gameRepository.AddAsync(domainGame);
        }

        public Task ChangeVisibility(int gameId, CancellationToken cancellation)
        {
            return _gameRepository.ChangeVisibility(gameId, cancellation);
        }

        public async Task DeleteAsync(int gameId, CancellationToken cancellation)
        {
            var game = await _gameRepository.GetGameByIdASync(gameId, cancellation);
            if(game.Images != null)
            {
                foreach (var image in game.Images)
                {
                    await _imageService.DeleteImageAsync(image.ImageId, cancellation);
                }
            }

            await _gameRepository.DeleteAsync(gameId, cancellation);
        }

        public Task<List<GameEntity>> GetAllAsync()
        {
            var result =  _gameRepository.GetAllGamesAsync();
            return result;
        }
    }
}
