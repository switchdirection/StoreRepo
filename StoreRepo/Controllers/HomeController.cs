using Application.Authentification;
using Application.Category.Repository;
using Application.Category.Services;
using Application.Games;
using Application.Games.Repositories;
using AutoMapper;
using Contracts.Games;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreRepo.Models;
using System.Diagnostics;

namespace StoreRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _dbContext;
        private readonly IAuthentificationService _authentificationService;

        public HomeController(
            ILogger<HomeController> logger,
            IGamesService gameService,
            ICategoryService categoryService,
            IMapper mapper,
            StoreDbContext dbContext,
            IAuthentificationService authentificationService)
        {
            _logger = logger;
            _gameService = gameService;
            _categoryService = categoryService;
            _mapper = mapper;
            _dbContext = dbContext;
            _authentificationService = authentificationService;
        }

        public async Task<IActionResult> Index()
        {
            _authentificationService.CheckAdminUser();
            //await _authentificationService.CheckAdminUser();
            //var gameEntity =  await _gameService.GetAllAsync();

            // var categoryEntity = await _categoryRepository.GetAllAsync();

            /*gameEntity[0].Categories.Add(categoryEntity[0]);
            gameEntity[1].Categories.Add(categoryEntity[1]);
            gameEntity[2].Categories.Add(categoryEntity[2]);

            _dbContext.SaveChanges();*/

            //ShortGameList gameElement = new ShortGameList();
            //_mapper.Map(gameEntity[0], gameElement);




            return View();
        }

        public async Task<IActionResult> AddGame(CancellationToken cancellation)
        {
            var categories = await _categoryService.GetAllCategories();

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        public async Task<IActionResult> AddGameMethod(ShortGameList gameDto, CancellationToken cancellation)
        {
            await _gameService.AddGameAsync(gameDto, cancellation);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
