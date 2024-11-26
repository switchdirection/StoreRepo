using Application.Orders.Repository;
using Application.Orders.Model;
using DataAccess.Common;
using Domain.Entities;
using Application.Orders.Service;
using Microsoft.EntityFrameworkCore;
using Application.OrdersHistory.Model;

namespace DataAccess.Orders.Repository
{
    /// <summary>
    /// Репозиторий по работе с заказами
    /// </summary>
    public sealed class OrderRepository : EntityFrameworkCoreBaseRepository<OrderEntity>, IOrderRepository
    {
        public StoreDbContext _dbContext { get; set; }
        public OrderRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task AddOrderAsync(OrderEntity order, CancellationToken cancellation)
        {
            await _dbContext.Set<OrderEntity>().AddAsync(order, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }
        /// <inheritdoc/>
        public async Task<List<OrderViewModel>> GetOrdersByUserIdForViewAsync(int userId, CancellationToken cancellation)
        {
            return await _dbContext
                .Set<OrderEntity>()
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    OrderDate = o.PurchaseDate,
                    TotalAmount = o.TotalPrice,
                    Status = o.Status
                }).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task EditOrderStatusByIdAsync(EditOrderHistoryModel model, CancellationToken cancellation)
        {
            await _dbContext
                .Set<OrderEntity>()
                .Where(o => o.OrderId == model.OrderId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(o => o.Status, model.Status), cancellation);
        }

    }
}
