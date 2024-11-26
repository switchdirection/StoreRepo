using Application.Category.Repository;
using Application.Category.Services;
using Application.Developers.Service;
using Application.Games;
using Application.Platforms.Service;
using Application.Publishers.Service;
using AutoMapper;
using Contracts.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contracts.Requests;
using Application.Games.Model;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер игр
    /// </summary>
    public class GameController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ICategoryService _categoryService;
        private readonly IDeveloperService _developerService;
        private readonly IPlatformService _platformService;
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;

        public GameController(
            IGamesService gameService,
            IMapper mapper,
            ICategoryService categoryService,
            IDeveloperService developerService,
            IPublisherService publisherService,
            IPlatformService platformService
            )
        {
            _gamesService = gameService;
            _mapper = mapper;
            _categoryService = categoryService;
            _developerService = developerService;
            _publisherService = publisherService;
            _platformService = platformService;
        }

        /// <summary>
        /// Метод контроллера для отображения игр
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> ShowGames(CancellationToken cancellation)
        {
            var games = await _gamesService.GetAllAsync();
            List<ShortGameList> gamesDto = new List<ShortGameList>(games.Count);
            foreach (var game in games)
            {
                var gameDto = _mapper.Map<ShortGameList>(game);
                foreach (var item in game.Images.OrderBy(i => i.ImageId))
                {
                    gameDto.ImageUrl = item.ImageUrl;
                    break;
                }
                gamesDto.Add(gameDto);
            }
            return View("GameView", gamesDto);
        }
        /// <summary>
        /// Метод контроллера для транспортировки данных на страницу добавления игры
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> AddGame(CancellationToken cancellation)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(cancellation);
            var developers = await _developerService.GetAllDevelopersAsync(cancellation);
            var publishers = await _publisherService.GetAllPublishersAsync(cancellation);
            var platforms = await _platformService.GetAllPlatformsAsync(cancellation);

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            ViewBag.Developers = new SelectList(developers, "DeveloperId", "DeveloperName");
            ViewBag.Publishers = new SelectList(publishers, "PublisherId", "PublisherName");
            ViewBag.Platforms = new SelectList(platforms, "PlatformId", "PlatformName");
            return View("AddGame");
        }
        /// <summary>
        /// Метод контроллера осуществляющий добавление игры
        /// </summary>
        /// <param name="gameDto">Игра</param>
        /// <param name="Categories">Выбранные категории</param>
        /// <param name="Developers">Выбранные разработчики</param>
        /// <param name="Publishers">Выбранные издатели</param>
        /// <param name="Platforms">Выбранные платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> AddGameMethod(ShortGameList gameDto, List<string> Categories, List<string> Developers, List<string> Publishers, List<string> Platforms, CancellationToken cancellation)
        {
            // Присвоение выбранных категорий
            gameDto.Categories = Categories.Select(c => new CategoryListDto { CategoryId = int.Parse(c) }).ToList();
            gameDto.Developers = Developers.Select(d => new DeveloperDto { DeveloperId = int.Parse(d) }).ToList();
            gameDto.Publishers = Publishers.Select(p => new PublisherDto { PublisherId = int.Parse(p) }).ToList();
            gameDto.Platforms = Platforms.Select(p => new PlatformDto { PlatformId = int.Parse(p) }).ToList();
            await _gamesService.AddGameAsync(gameDto, cancellation);
            TempData["GameAdded"] = "Игра успешно добавлена";
            return RedirectToAction("ShowGames");
        }

        /// <summary>
        /// Метод контроллера для транспортировки данных на страницу редактирования игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> GameEditView(int id, CancellationToken cancellation)
        {
            var game = await _gamesService.GetGameByIdASync(id, cancellation);
            if(game == null)
            {
                return NotFound();
            }

            var allCategories = await _categoryService.GetAllCategoriesDtoAsync(cancellation);
            var allDevelopers = await _developerService.GetAllDevelopersDtoAsync(cancellation);
            var allPublishers = await _publisherService.GetAllPublishersDtoAsync(cancellation);
            var allPlatforms = await _platformService.GetAllPlatformsDtoAsync(cancellation);
            var model = new GameEditModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                StockQuantity = game.StockQuantity,
                Price = game.Price,
                Rating = game.Rating,
                IsDeleted = game.IsDeleted,
                SelectedCategoryIds = game.Categories.Select(c => c.CategoryId).ToList(),
                SelectedDeveloperIds = game.Developers.Select(d => d.DeveloperId).ToList(),
                SelectedPublisherIds = game.Publishers.Select(p => p.PublisherId).ToList(),
                SelectedPlatformIds = game.Platforms.Select(p => p.PlatformId).ToList(),
                AllCategories = allCategories,
                AllDevelopers = allDevelopers,
                AllPublishers = allPublishers,
                AllPlatforms = allPlatforms
            };

            return View("EditGameView", model);
        }

        /// <summary>
        /// Метод контроллера осуществляющий редактирования игры
        /// </summary>
        /// <param name="model">Модель для редактирования игры</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> GameEdit(GameEditModel model, CancellationToken cancellation)
        {
            var result = await _gamesService.UpdateGameAsync(model, cancellation);
            if (result)
            {
                TempData["GameUpdatedSuccess"] = "Игра успешно обновлена.";
            }
            else
            {
                TempData["GameUpdatedError"] = "Игра не была обновлена.";
            }
            return RedirectToAction("ShowGames");
        }
        /// <summary>
        /// Метод контроллера для изменения параметра видимости игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> ChangeVisibility(int id, CancellationToken cancellation)
        {
           await _gamesService.ChangeVisibilityAsync(id, cancellation);
           return RedirectToAction("ShowGames");
        }
        /// <summary>
        /// Метод контроллера осуществляющий удаления игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> Delete(int gameId, CancellationToken cancellation)
        {
            await _gamesService.DeleteAsync(gameId, cancellation);
            TempData["GameDeleted"] = "Игра успешно удалена";
            return RedirectToAction("ShowGames");
        }
    }
}
