using Application.Cart.Service;
using Application.Games;
using Application.Games.Model;
using Application.Users;
using AutoMapper;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;
using System.Diagnostics;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gameService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public HomeController(
            ILogger<HomeController> logger,
            IGamesService gameService,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            ICartService cartService,
            IUserService userService
            )
        {
            _logger = logger;
            _gameService = gameService;
            _mapper = mapper;
            _userManager = userManager;
            _cartService = cartService;
            _userService = userService;
        }

        /// <summary>
        /// Метод контроллера загрузки главной страницы
        /// </summary>
        /// <param name="search">Поле поиска</param>
        /// <param name="categories">Выбранные категории</param>
        /// <param name="minPrice">Минимальное значение цены</param>
        /// <param name="maxPrice">Максимальное значение цены</param>
        /// <param name="developers">Выбранные разработчики</param>
        /// <param name="platforms">Выбранные платформы</param>
        /// <param name="publishers">Выбранные издатели</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> Index(string search, int[] categories, int? minPrice, int? maxPrice, int[] developers, int[] platforms, int[] publishers, int pageNumber = 1, CancellationToken cancellation = default)
        {
            await _userService.CreateAdminUserAsync(cancellation);

            var filters = await _gameService.GetFilterOptionsAsync(cancellation);

            var gameEntity =  await _gameService.GetAllNotDeletedAsync(new PagedRequest
            {
                PageNumber = pageNumber,
                PageSize = 6,
                Search = search,
                Categories = categories,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Developers = developers,
                Platforms = platforms,
                Publishers = publishers
            }, cancellation);

            var viewModel = new GameViewModel
            {
                Filters = filters,
                Games = gameEntity
            };


            return View("Index", viewModel);
        }

        /// <summary>
        /// Метод контроллера получения подробной информации о игре
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> GetGameDetails(int gameId, CancellationToken cancellation)
        {
            var game = await _gameService.GetGameByIdASync(gameId, cancellation); // Получите продукт из базы данных или сервиса

            var gameDto = _mapper.Map<ShortGameList>(game);
            var images = new List<string>(game.Images.Count - 1);
            byte count = 0;
            foreach (var item in game.Images.OrderBy(i => i.ImageId))
            {
                if(count == 0)
                {
                    gameDto.ImageUrl = item.ImageUrl;
                    count += 1;
                }
                else
                {
                    images.Add(item.ImageUrl);
                }
            }

            gameDto.ImagesUrls = images.ToArray();

            return PartialView("_GameDetailsPartial", gameDto); // Вернём данные продукта
        }
        /// <summary>
        /// Метод контроллера для добавления игры в корзину
        /// </summary>
        /// <param name="request">Запрос на добавление игры в корзину</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.CartId == 0)
            {
                await _userService.AddCartToUserAsync(user.Id.ToString(), cancellation);
            }

            var cart = await _cartService.GetByIdAsync(user.CartId, cancellation);
            user.Cart = cart;

            var result = await _cartService.AddGameToCart(request.GameId, user, cancellation);

            if (result)
            {
                TempData["ItemAddToCartSuccess"] = "Товар успешно добавлен в корзину";
            }
            else
            {
                TempData["ItemAddToCartError"] = "Товар не был добавлен в корзину";
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
