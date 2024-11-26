using Application.OrdersHistory.Model;
using Application.OrdersHistory.Repository;
using AutoMapper;
using Contracts.Orders;
using Contracts.Requests;
using Domain.Entities;

namespace Application.OrdersHistory.Service
{
    /// <summary>
    /// Сервис по работе с историей заказов
    /// </summary>
    public sealed class OrdersHistoryService : IOrdersHistoryService
    {
        private readonly IOrdersHistoryRepository _orderHistoryRepository;
        private readonly IMapper _mapper;
        public OrdersHistoryService(IOrdersHistoryRepository orderHistoryRepository, IMapper mapper)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task AddOrderToHistoryAsync(AddOrderRequest request, OrderEntity order, CancellationToken cancellation)
        {
            var orderHistory = new OrdersHistoryEntity
            {
                UserId = order.UserId,
                FullUserName = GetFullUserName(request),
                PaymentType = request.paymentType,
                Status = order.Status,
                OrderPrice = order.TotalPrice,
                PurchaseDate = order.PurchaseDate
            };

           await _orderHistoryRepository.AddOrderToHistoryAsync(orderHistory, cancellation);
        }

        /// <inheritdoc/>
        public Task<bool> DeleteOrdersHistoryByIdAsync(int orderId, CancellationToken cancellation)
        {
            return _orderHistoryRepository.DeleteOrdersHistoryByIdAsync(orderId, cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> EditOrderHistoryAsync(EditOrderHistoryModel model, CancellationToken cancellation)
        {
            return await _orderHistoryRepository.EditOrderHistoryAsync(model, cancellation);
        }

        /// <inheritdoc/>
        public async Task<List<OrdersHistoryDto>> GetOrdersHistoryAsync(CancellationToken cancellation)
        {
            var ordersHistory = await _orderHistoryRepository.GetOrdersHistoryAsync(cancellation);
            var ordersHistoryDto = _mapper.Map<List<OrdersHistoryDto>>(ordersHistory);
            return ordersHistoryDto;
        }

        /// <summary>
        /// Метод для получения ФИО пользователя
        /// </summary>
        /// <param name="request">Запрос на добавления заказа</param>
        /// <returns></returns>
        private string GetFullUserName(AddOrderRequest request)
        {
            return request.userLastname + " " + request.userName + " " + request.userSurname;
        }
    }
}
