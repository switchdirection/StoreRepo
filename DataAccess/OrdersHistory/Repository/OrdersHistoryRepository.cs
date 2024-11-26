using DataAccess.Common;
using Domain.Entities;
using Application.OrdersHistory.Repository;
using Microsoft.EntityFrameworkCore;
using Application.OrdersHistory.Model;

namespace DataAccess.OrdersHistory.Repository
{
    /// <summary>
    /// Репозиторий по работе с заказами
    /// </summary>
    public sealed class OrdersHistoryRepository : EntityFrameworkCoreBaseRepository<OrdersHistoryEntity>, IOrdersHistoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrdersHistoryRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task AddOrderToHistoryAsync(OrdersHistoryEntity orderHistory, CancellationToken cancellation)
        {
            await _dbContext.Set<OrdersHistoryEntity>().AddAsync(orderHistory, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteOrdersHistoryByIdAsync(int orderId, CancellationToken cancellation)
        {
            await _dbContext.Set<OrdersHistoryEntity>().Where(o => o.Id == orderId).AsSplitQuery().ExecuteDeleteAsync(cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> EditOrderHistoryAsync(EditOrderHistoryModel model, CancellationToken cancellation)
        {
            await _dbContext
                .Set<OrdersHistoryEntity>()
                .Where(o => o.Id == model.OrderId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.FullUserName, model.FIO)
                    .SetProperty(o => o.PaymentType, model.PaymentType)
                    .SetProperty(o => o.Status, model.Status));
            return true;

        }

        /// <inheritdoc/>
        public async Task<List<OrdersHistoryEntity>> GetOrdersHistoryAsync(CancellationToken cancellation)
        {
            return await _dbContext.Set<OrdersHistoryEntity>().AsSplitQuery().ToListAsync();
        }
    }
}
