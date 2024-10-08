using Application.Category.Repository;
using Application.Games.Repositories;
using AutoMapper;
using Contracts.Games;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreRepo.Models;
using System.Diagnostics;

namespace StoreRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _dbContext;

        public HomeController(
            ILogger<HomeController> logger,
            IGameRepository gameRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            StoreDbContext dbContext)
        {
            _logger = logger;
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var gameEntity = await _gameRepository.GetAllAsync();
            
            var categoryEntity = await _categoryRepository.GetAllAsync();

            /*gameEntity[0].Categories.Add(categoryEntity[0]);
            gameEntity[1].Categories.Add(categoryEntity[1]);
            gameEntity[2].Categories.Add(categoryEntity[2]);

            _dbContext.SaveChanges();*/

            ShortGameList gameElement = new ShortGameList();
            _mapper.Map(gameEntity[0], gameElement);

            
             

            return View(gameElement);
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
