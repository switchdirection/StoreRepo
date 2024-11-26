using Application.OrdersHistory.Model;
using Contracts.Orders;
using Contracts.Requests;
using Domain.Entities;

namespace Application.OrdersHistory.Service
{
    /// <summary>
    /// Интерфейс сервиса по работе с историей заказа
    /// </summary>
    public interface IOrdersHistoryService
    {
        /// <summary>
        /// Метод для добавления истории заказа по запросу
        /// </summary>
        /// <param name="request">Запрос на добавление истории заказа</param>
        /// <param name="order">Заказ</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddOrderToHistoryAsync(AddOrderRequest request, OrderEntity order, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения истории заказов
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<OrdersHistoryDto>> GetOrdersHistoryAsync(CancellationToken cancellation);
        /// <summary>
        /// Удалить историю заказа по идентификатору 
        /// </summary>
        /// <param name="orderId">Идентификатор заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> DeleteOrdersHistoryByIdAsync(int orderId, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования истории заказа
        /// </summary>
        /// <param name="model">Модель для редактирования</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> EditOrderHistoryAsync(EditOrderHistoryModel model, CancellationToken cancellation);
    }
}
