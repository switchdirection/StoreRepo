using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллр по работе с ролями
    /// </summary>
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
