using Application.Orders.Service;
using Application.OrdersHistory.Model;
using Application.OrdersHistory.Service;
using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер истории заказа
    /// </summary>
    public class OrdersHistoryController : Controller
    {
        private readonly IOrdersHistoryService _ordersHistoryService;
        private readonly IOrderService _orderService;
        public OrdersHistoryController(
            IOrdersHistoryService ordersHistoryService,
            IOrderService orderService
            )
        {
            _ordersHistoryService = ordersHistoryService;
            _orderService = orderService;
        }

        /// <summary>
        /// Метод контроллера удаляющий заказ из истории
        /// </summary>
        /// <param name="orderId">Идентификатор заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId, CancellationToken cancellation)
        {
            bool result = await _ordersHistoryService.DeleteOrdersHistoryByIdAsync(orderId, cancellation);
            if (result)
            {
                TempData["OrderDeletedSuccess"] = "История заказа успешно удалена";
            }
            else
            {
                TempData["OrderDeletedError"] = "История заказа не была удалена";
            }
            return View("ShowOrdersHistory");
        }
        /// <summary>
        /// Метод контроллера для изменения заказа в истории
        /// </summary>
        /// <param name="model">Модель для редактирования заказа в истории</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> EditOrderHistory(EditOrderHistoryModel model, CancellationToken cancellation)
        {
            bool result = await _ordersHistoryService.EditOrderHistoryAsync(model, cancellation);
            await _orderService.EditOrderStatusByIdAsync(model, cancellation);
            if (result)
            {
                TempData["OrderEditedSuccess"] = "История заказа успешно отредактирована";
            }
            else
            {
                TempData["OrderEditedError"] = "История заказа не была отредактирована";
            }
            return RedirectToAction("ShowOrdersHistory", "Order");
        }
    }
}
