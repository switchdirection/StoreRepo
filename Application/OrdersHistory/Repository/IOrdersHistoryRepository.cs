using Application.Common;
using Application.OrdersHistory.Model;
using Domain.Entities;

namespace Application.OrdersHistory.Repository
{
    /// <summary>
    /// Интерфейс репозитория по работе с историей заказов
    /// </summary>
    public interface IOrdersHistoryRepository : IRepository<OrdersHistoryEntity>
    {
        /// <summary>
        /// Добавление истории заказа
        /// </summary>
        /// <param name="orderHistory">История заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddOrderToHistoryAsync(OrdersHistoryEntity orderHistory, CancellationToken cancellation);
        /// <summary>
        /// Метод для получения истории заказов
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<OrdersHistoryEntity>> GetOrdersHistoryAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления истории заказа по идентификатору
        /// </summary>
        /// <param name="orderId">Идентификатор истории заказа</param>
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
