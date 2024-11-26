using Application.Cart.Service;
using Application.Orders.Model;
using Application.Orders.Repository;
using Application.OrdersHistory.Model;
using Application.OrdersHistory.Service;
using AutoMapper;
using Contracts.Orders;
using Contracts.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Orders.Service
{
    /// <summary>
    /// Сервис по работе с заказами
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;
        private readonly IOrdersHistoryService _ordersHistoryService;
        private readonly IMapper _mapper;
        public OrderService(
            IOrderRepository orderRepository,
            UserManager<ApplicationUser> userManager,
            ICartService cartService,
            IOrdersHistoryService ordersHistoryService,
            IMapper mapper
            )
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _cartService = cartService;
            _ordersHistoryService = ordersHistoryService;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<bool> AddOrderAsync(int userId, AddOrderRequest request, CancellationToken cancellation)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if(user.Cart == null)
            {
                user.Cart = await _cartService.GetByIdAsync(user.CartId, cancellation);
            }

            var order = new OrderEntity
            {
                UserId = userId,
                User = user,
                TotalPrice = request.totalPrice,
                Games = user.Cart.Games,
                PurchaseDate = DateTime.UtcNow
            };

            await _orderRepository.AddOrderAsync(order, cancellation);

            await _ordersHistoryService.AddOrderToHistoryAsync(request, order, cancellation);

            user.Cart.Games.Clear();
            await _userManager.UpdateAsync(user);
            return true;
        }

        /// <inheritdoc/>
        public async Task EditOrderStatusByIdAsync(EditOrderHistoryModel model, CancellationToken cancellation)
        {
            await _orderRepository.EditOrderStatusByIdAsync(model, cancellation);
        }

        /// <inheritdoc/>
        public async Task<OrderDto> GetOrderByIdAsync(int id, ApplicationUser user, CancellationToken cancellation)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);
            var orderDto = _mapper.Map<OrderDto>(orderEntity);
            orderDto.UserName = user.UserName;
            return orderDto;
        }

        /// <inheritdoc/>
        public Task<List<OrderViewModel>> GetOrdersByUserIdForViewAsync(int userId, CancellationToken cancellation)
        {
            return _orderRepository.GetOrdersByUserIdForViewAsync(userId, cancellation);
        }
    }
}
