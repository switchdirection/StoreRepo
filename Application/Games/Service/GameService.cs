using Application.Category.Services;
using Application.Developers.Service;
using Application.Games.Filters;
using Application.Games.Model;
using Application.Games.Repositories;
using Application.Images.Services;
using Application.Platforms.Service;
using Application.Publishers.Service;
using AutoMapper;
using Contracts.Common;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Games
{
    /// <summary>
    /// Сервис по работе с играми
    /// </summary>
    public sealed class GameService : IGamesService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly IDeveloperService _developerService;
        private readonly IPublisherService _publisherService;
        private readonly IPlatformService _platformService;
        public GameService(
            IGameRepository gameRepository,
            IMapper mapper,
            IImageService imageService,
            ICategoryService categoryService,
            IDeveloperService developerService,
            IPublisherService publisherService,
            IPlatformService platformService
        )
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _imageService = imageService;
            _categoryService = categoryService;
            _developerService = developerService;
            _publisherService = publisherService;
            _platformService = platformService;
        }
        /// <inheritdoc/>
        public async Task AddGameAsync(ShortGameList game, CancellationToken cancellation)
        {
            var categories = new List<CategoryEntity>(game.Categories.Count);
            var developers = new List<DeveloperEntity>(game.Developers.Count);
            var publishers = new List<PublisherEntity>(game.Publishers.Count);
            var platforms = new List<PlatformEntity>(game.Platforms.Count);
            
            foreach (var category in game.Categories)
            {
                categories.Add(await _categoryService.GetCategoryByIdAsync(category.CategoryId, cancellation)); 
            }
            foreach (var developer in game.Developers)
            {
                developers.Add(await _developerService.GetDeveloperByIdAsync(developer.DeveloperId, cancellation));
            }
            foreach (var publisher in game.Publishers)
            {
                publishers.Add(await _publisherService.GetPublisherByIdAsync(publisher.PublisherId, cancellation));
            }
            foreach (var platform in game.Platforms)
            {
                platforms.Add(await _platformService.GeetPlatformByIdAsync(platform.PlatformId, cancellation));
            }


            game.Categories = null;
            game.Developers = null;
            game.Publishers = null;
            game.Platforms = null;

            var domainGame = _mapper.Map<GameEntity>(game);
            
            foreach(var category in categories)
            {
                domainGame.Categories.Add(category);
            }
            foreach (var developer in developers)
            {
                domainGame.Developers.Add(developer);
            }
            foreach (var publisher in publishers)
            {
                domainGame.Publishers.Add(publisher);
            }
            foreach (var platform in platforms)
            {
                domainGame.Platforms.Add(platform);
            }

            domainGame.Images = await _imageService.SaveImageEntityAsync(game.ImageUrl, game.ImagesUrls, domainGame, cancellation);
            domainGame.ReleaseDate = DateTime.UtcNow;

            await _gameRepository.AddAsync(domainGame);
        }

        /// <inheritdoc/>
        public Task ChangeVisibilityAsync(int gameId, CancellationToken cancellation)
        {
            return _gameRepository.ChangeVisibilityAsync(gameId, cancellation);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public Task<List<GameEntity>> GetAllAsync()
        {
            var result =  _gameRepository.GetAllGamesAsync();
            return result;
        }

        /// <inheritdoc/>
        public async Task<ShortGameEntityList> GetAllNotDeletedAsync(PagedRequest request, CancellationToken cancellation)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var totalCount = await _gameRepository.GetGamesTotalCountAsync(cancellation);

            if (totalCount == 0)
            {
                return new ShortGameEntityList
                {
                    PageNumber = 1,
                    TotalCount = totalCount,
                    PageSize = 1,
                    Result = []
                };
            }

            var result = await _gameRepository.GetAllNotDeletedAsync(new GetGamesRequest
            {
                Take = request.PageSize,
                Skip = (request.PageNumber - 1) * request.PageSize,
                Search = request.Search,
                Categories = request.Categories,
                MinPrice = request.MinPrice,
                MaxPrice = request.MaxPrice,
                Platforms = request.Platforms,
                Developers = request.Developers,
                Publishers = request.Publishers,
            }, cancellation);


            var shortGames = result.Select(game =>
            {
                var gameDto = _mapper.Map<ShortGameList>(game);
                var images = game.Images.OrderBy(i => i.ImageId).ToList();

                if (images.Any())
                {
                    gameDto.ImageUrl = images.First().ImageUrl;
                    gameDto.ImagesUrls = images.Skip(1).Select(i => i.ImageUrl).ToArray();
                }

                return gameDto;
            }).ToList();

            var category = await _categoryService.GetAllCategoriesAsync(cancellation);
            var developer = await _developerService.GetAllDevelopersAsync(cancellation);
            var publisher = await _publisherService.GetAllPublishersAsync(cancellation);
            var platform = await _platformService.GetAllPlatformsAsync(cancellation);

            return new ShortGameEntityList
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Categories = _mapper.Map<List<CategoryListDto>>(category),
                Developers = _mapper.Map<List<DeveloperDto>>(developer),
                Publishers = _mapper.Map<List<PublisherDto>>(publisher),
                Platforms = _mapper.Map<List<PlatformDto>>(platform),
                Result = shortGames
            };
        }

        /// <inheritdoc/>
        public async Task<GameFilters> GetFilterOptionsAsync(CancellationToken cancellation)
        {
            var categories = await _categoryService.GetAllCategoriesDtoAsync(cancellation);
            var developers = await _developerService.GetAllDevelopersDtoAsync(cancellation);
            var publishers = await _publisherService.GetAllPublishersDtoAsync(cancellation);
            var platforms = await _platformService.GetAllPlatformsDtoAsync(cancellation);
            return new GameFilters
            {
                Categories = categories,
                Developers = developers,
                Publishers = publishers,
                Platforms = platforms
            };
        }

        /// <inheritdoc/>
        public Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation)
        {
            return _gameRepository.GetGameByIdASync(id, cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateGameAsync(GameEditModel model, CancellationToken cancellation)
        {
            try
            {
                await _gameRepository.UpdateGameAsync(model, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
