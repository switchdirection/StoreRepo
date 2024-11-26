using Application.Common;
using Application.Orders.Model;
using Application.OrdersHistory.Model;
using Domain.Entities;

namespace Application.Orders.Repository
{

    /// <summary>
    /// Интерфейс репозитория по работе с заказами
    /// </summary>
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        /// <summary>
        /// Метод для добавления заказа
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddOrderAsync(OrderEntity order, CancellationToken cancellation);
        /// <summary>
        /// Методя для добваления заказа по иднетификатору пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<OrderViewModel>> GetOrdersByUserIdForViewAsync(int userId, CancellationToken cancellation);
        /// <summary>
        /// Метод для изменения статуса заказа
        /// </summary>
        /// <param name="model">Модель для редактирования заказа</param>
        /// <param name="cancellation">Токен отмены</param>
        Task EditOrderStatusByIdAsync(EditOrderHistoryModel model, CancellationToken cancellation);
    }
}
