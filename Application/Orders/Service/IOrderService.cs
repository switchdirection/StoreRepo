using Application.Orders.Model;
using Application.OrdersHistory.Model;
using Contracts.Orders;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Orders.Service
{
    /// <summary>
    /// Интерфейс серсива по работе с заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Метод добавления заказа
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="request">Запрос на добавления заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> AddOrderAsync(int userId, AddOrderRequest request, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения заказа конкретного пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<OrderViewModel>> GetOrdersByUserIdForViewAsync(int userId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования заказа
        /// </summary>
        /// <param name="model">Модель редактирования заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        Task EditOrderStatusByIdAsync(EditOrderHistoryModel model, CancellationToken cancellation);
        /// <summary>
        /// Методя для получения заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="user">Пользователь</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<OrderDto> GetOrderByIdAsync(int id, ApplicationUser user, CancellationToken cancellation);
    }
}
