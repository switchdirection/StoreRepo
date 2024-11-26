using Application.Developers.Model;
using Application.Developers.Service;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер разработчика
    /// </summary>
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        /// <summary>
        /// Метод контроллера отображающий страницу со всеми разработчиками
        /// </summary>
        /// <param name="searchQuery">Поисковой запрос</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> ShowDevelopers(string searchQuery, CancellationToken cancellation)
        {
            var developers = await _developerService.GetAllDevelopersDtoAsync(cancellation);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                developers = developers.Where(d => d.DeveloperName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View("DevelopersView", developers);
        }
        /// <summary>
        /// Метод контроллера для удаления разработчика
        /// </summary>
        /// <param name="developerId">Идентификатор разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> DeleteDeveloper(int developerId, CancellationToken cancellation)
        {
            var result = await _developerService.DeleteDeveloperAsync(developerId, cancellation);
            if (result)
            {
                TempData["DeletedDeveloperSuccess"] = "Разработчик был успешно удален";
            }
            else
            {
                TempData["DeletedDeveloperError"] = "Разработчик не был удален";
            }
            return RedirectToAction("ShowDevelopers");
        }
        /// <summary>
        /// Метод контроллера для редактирования разработчика
        /// </summary>
        /// <param name="model">Модель редактирования разработчика</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> EditDeveloper(EditDeveloperModel model, CancellationToken cancellation)
        {
            if(string.IsNullOrEmpty(model.DeveloperUrl) || string.IsNullOrWhiteSpace(model.DeveloperUrl))
            {
                model.DeveloperUrl = "Не указан";
            }
            var result = await _developerService.EditDeveloperAsync(model, cancellation);
            if (result)
            {
                TempData["EditDeveloperSuccess"] = "Разработчик был успешно отредактирован";
            }
            else
            {
                TempData["EditDeveloperError"] = "Разработчик не был отредактирован";
            }
            return RedirectToAction("ShowDevelopers");
        }

        /// <summary>
        /// Метод контроллера для добавления разработчика
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellation"></param>
        [HttpPost]
        public async Task<IActionResult> AddDeveloper(AddDeveloperRequest request, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(request.DeveloperWebsite) || string.IsNullOrWhiteSpace(request.DeveloperWebsite))
            {
                request.DeveloperWebsite = "Не указан";
            }
            var result = await _developerService.AddDeveloperByRequestAsync(request, cancellation);
            if (result)
            {
                TempData["AddDeveloperSuccess"] = "Разработчик добавлен успешно";
            }
            else
            {
                TempData["AddDeveloperError"] = "Разработчик не был добавлен";
            }

            return RedirectToAction("ShowDevelopers");
        }
    }
}
