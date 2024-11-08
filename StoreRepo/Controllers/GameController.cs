using Application.Category.Repository;
using Application.Category.Services;
using Application.Games;
using AutoMapper;
using Contracts.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StoreRepo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GameController(
            IGamesService gameService,
            IMapper mapper,
            ICategoryService categoryService
            )
        {
            _gamesService = gameService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

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

        [HttpGet]
        public async Task<IActionResult> AddGame(CancellationToken cancellation)
        {
            var categories = await _categoryService.GetAllCategories();

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View("AddGame");
        }

        public async Task<IActionResult> AddGameMethod(ShortGameList gameDto, List<string> Categories, CancellationToken cancellation)
        {
            // Присвоение выбранных категорий
            gameDto.Categories = Categories.Select(c => new CategoryListDto { CategoryId = c }).ToList();
            await _gamesService.AddGameAsync(gameDto, cancellation);
            TempData["GameAdded"] = "Игра успешно добавлена";
            return RedirectToAction("ShowGames");
        }

        public async Task<IActionResult> ChangeVisibility(int id, CancellationToken cancellation)
        {
           await _gamesService.ChangeVisibility(id, cancellation);
           return RedirectToAction("ShowGames");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int gameId, CancellationToken cancellation)
        {
            await _gamesService.DeleteAsync(gameId, cancellation);
            TempData["GameDeleted"] = "Игра успешно удалена";
            return RedirectToAction("ShowGames");
        }
    }
}
