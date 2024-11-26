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
    /// ���������� ������� ��������
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
        /// ����� ����������� �������� ������� ��������
        /// </summary>
        /// <param name="search">���� ������</param>
        /// <param name="categories">��������� ���������</param>
        /// <param name="minPrice">����������� �������� ����</param>
        /// <param name="maxPrice">������������ �������� ����</param>
        /// <param name="developers">��������� ������������</param>
        /// <param name="platforms">��������� ���������</param>
        /// <param name="publishers">��������� ��������</param>
        /// <param name="pageNumber">����� ��������</param>
        /// <param name="cancellation">����� ������</param>
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
        /// ����� ����������� ��������� ��������� ���������� � ����
        /// </summary>
        /// <param name="gameId">������������� ����</param>
        /// <param name="cancellation">����� ������</param>
        [HttpGet]
        public async Task<IActionResult> GetGameDetails(int gameId, CancellationToken cancellation)
        {
            var game = await _gameService.GetGameByIdASync(gameId, cancellation); // �������� ������� �� ���� ������ ��� �������

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

            return PartialView("_GameDetailsPartial", gameDto); // ����� ������ ��������
        }
        /// <summary>
        /// ����� ����������� ��� ���������� ���� � �������
        /// </summary>
        /// <param name="request">������ �� ���������� ���� � �������</param>
        /// <param name="cancellation">����� ������</param>
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
                TempData["ItemAddToCartSuccess"] = "����� ������� �������� � �������";
            }
            else
            {
                TempData["ItemAddToCartError"] = "����� �� ��� �������� � �������";
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
