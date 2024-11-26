using Application.Orders.Service;
using Application.OrdersHistory.Service;
using Contracts.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.Email.Service;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллера заказа
    /// </summary>
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrdersHistoryService _ordersHistoryService;
        private readonly IEmailService _emailService;
        public OrderController(IOrderService orderService,
            UserManager<ApplicationUser> userManager,
            IOrdersHistoryService ordersHistoryService,
            IEmailService emailService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _ordersHistoryService = ordersHistoryService;
            _emailService = emailService;
        }

        /// <summary>
        /// Метод контроллера перенаправляющий на страницу введение информации для оформления заказа
        /// </summary>
        /// <param name="totalPrice">Цена заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public IActionResult PlaceAnOrder(double totalPrice, CancellationToken cancellation)
        {
            return View("PlaceAnOrderView", totalPrice);
        }
        /// <summary>
        /// Метод контроллера для подтверждения заказа
        /// </summary>
        /// <param name="request">Запрос на добавление заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder([FromBody] AddOrderRequest request, CancellationToken cancellation)
        {
            if (request == null)
            {
                return BadRequest("Не предоставленны данные для подтверждения заказа");
            }

            var user = await _userManager.GetUserAsync(User);

            _emailService.SendMailToBuyer(request, user);
            
            var result = await _orderService.AddOrderAsync(user.Id, request, cancellation);
            if (result)
            {
                TempData["OrderAddedSuccess"] = "Заказа успешно добавлен в обработку";
            }
            else
            {
                TempData["OrderAddedError"] = "Заказ не был добавлен в обработку";
            }
            return Ok();
        }
        /// <summary>
        /// Метод контроллера для отображения деталей заказа
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> Details(int id, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var order = await _orderService.GetOrderByIdAsync(id, user, cancellation);

            if (order == null)
            {
                return NotFound();
            }

            return Json(order); 
        }
        /// <summary>
        /// Метод контроллера для отображения страницы истории заказа
        /// </summary>
        /// <param name="searchByName">Поисковой запрос по имени</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <param name="filterByStatus">Параметр фильтрации по статусу заказа</param>
        public async Task<IActionResult> ShowOrdersHistory(string searchByName, CancellationToken cancellation, string filterByStatus = "Все")
        {
            var ordersHistory = await _ordersHistoryService.GetOrdersHistoryAsync(cancellation);

            if (!string.IsNullOrEmpty(searchByName))
            {
                ordersHistory = ordersHistory.Where(o => o.FullUserName.Contains(searchByName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filterByStatus != "Все")
            {
                ordersHistory = ordersHistory.Where(o => o.Status == filterByStatus).ToList();
            }

            ViewBag.SearchByName = searchByName;
            ViewBag.FilterByStatus = filterByStatus;

            return View("../Order/OrdersView", ordersHistory);
        }

    }
}
