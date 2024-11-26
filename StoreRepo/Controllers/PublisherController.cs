using Application.Publishers.Model;
using Application.Publishers.Service;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер издателей
    /// </summary>
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        /// <summary>
        /// Метод контроллера для отображения страницы с издателями
        /// </summary>
        /// <param name="searchQuery">Поисковой запрос</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        public async Task<IActionResult> ShowPublishers(string searchQuery, CancellationToken cancellation) 
        {
            var publisherDto = await _publisherService.GetAllPublishersDtoAsync(cancellation);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                publisherDto = publisherDto.Where(p => p.PublisherName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View("PublishersView", publisherDto);
        }
        /// <summary>
        /// Метод контроллера для удаления издателя
        /// </summary>
        /// <param name="publisherId">Идентификатор издателя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> DeletePublisher(int publisherId, CancellationToken cancellation)
        {
            var result = await _publisherService.DeletePublisherAsync(publisherId, cancellation);
            if (result)
            {
                TempData["DeletedPublisherSuccess"] = "Издатель был успешно удален";
            }
            else
            {
                TempData["DeletedPublisherError"] = "Издатель не был удален";
            }
            return RedirectToAction("ShowPublishers");
        }
        /// <summary>
        /// Метод контроллера для редактирования издателя
        /// </summary>
        /// <param name="model">Модель для редактирования издателя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> EditPublisher(EditPublisherModel model, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(model.PublisherUrl) || string.IsNullOrWhiteSpace(model.PublisherUrl))
            {
                model.PublisherUrl = "Не указан";
            }
            var result = await _publisherService.EditPublisherAsync(model, cancellation);
            if (result)
            {
                TempData["EditPublisherSuccess"] = "Издатель был успешно отредактирован";
            }
            else
            {
                TempData["EditPublisherError"] = "Издатель не был отредактирован";
            }
            return RedirectToAction("ShowPublishers");
        }
        /// <summary>
        /// Метод контроллера для добавления издателя
        /// </summary>
        /// <param name="request">Запрос на добавления издателя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> AddPublisher(AddPublisherRequest request, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(request.PublisherWebsite) || string.IsNullOrWhiteSpace(request.PublisherWebsite))
            {
                request.PublisherWebsite = "Не указан";
            }
            var result = await _publisherService.AddPublisherByRequestAsync(request, cancellation);
            if (result)
            {
                TempData["AddPublisherSuccess"] = "Издатель добавлен успешно";
            }
            else
            {
                TempData["AddPublisherError"] = "Издатель не был добавлен";
            }

            return RedirectToAction("ShowPublishers");
        }
    }
}
