using DataAccess.Common;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;
using System.Diagnostics;

namespace StoreRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /*private readonly StoreDbContext _dbContext;*/

        public HomeController(ILogger<HomeController> logger/*, StoreDbContext dbContext*/)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
