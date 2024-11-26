using Application.Platforms.Model;
using Application.Platforms.Service;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер платформы
    /// </summary>
    public class PlatformController : Controller
    {
        private readonly IPlatformService _platformService;
        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        /// <summary>
        /// Метод контроллера для отображения страницы со всеми платформами
        /// </summary>
        /// <param name="searchQuery">Поисковой запрос</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> ShowPlatforms(string searchQuery, CancellationToken cancellation)
        {
            var platforms = await _platformService.GetAllPlatformsDtoAsync(cancellation);

            if(!string.IsNullOrEmpty(searchQuery))
            {
                platforms = platforms.Where(p => p.PlatformName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View("PlatformView", platforms);
        }
        /// <summary>
        /// Метод контроллера для удаления платформы
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> DeletePlatform(int platformId, CancellationToken cancellation)
        {
            var result = await _platformService.DeletePlatformAsync(platformId, cancellation);
            if (result)
            {
                TempData["DeletedPlatformSuccess"] = "Платформа успешно удалена";
            }
            else
            {
                TempData["DeletedPlatformError"] = "Платформа не была удалена";
            }
            return RedirectToAction("ShowPlatforms");
        }
        /// <summary>
        /// Метод контроллера для редактирования платформы
        /// </summary>
        /// <param name="model">Модель для редактирования платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> EditPlatform(EditPlatformModel model, CancellationToken cancellation)
        {
            var result = await _platformService.EditPlatformAsync(model, cancellation);
            if (result)
            {
                TempData["EditPlatformSuccess"] = "Платформа была успешно отредактирована";
            }
            else
            {
                TempData["EditPlatformSuccess"] = "Платформа не была отрекдатирована";
            }
            return RedirectToAction("ShowPlatforms");
        }
        /// <summary>
        /// Метод контроллера для добавления платформы
        /// </summary>
        /// <param name="request">Запрос на добавления платформы</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> AddPlatform(AddPlatformRequest request, CancellationToken cancellation)
        {
            var result = await _platformService.AddPlatformAsync(request.platformName, cancellation);
            if (result)
            {
                TempData["AddPlatformSuccess"] = "Платформа добавлена успешно";
            }
            else
            {
                TempData["AddPlatformError"] = "Платформа не была добавленна";
            }

            return RedirectToAction("ShowPlatforms");
        }
    }
}
