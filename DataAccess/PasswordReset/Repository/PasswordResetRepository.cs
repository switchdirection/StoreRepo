using DataAccess.Common;
using Domain.Entities;
using Application.PasswordReset.Repository;
using Contracts.Requests;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PasswordReset.Repository
{
    /// <summary>
    /// Репозиторий для сброса пароля
    /// </summary>
    public sealed class PasswordResetRepository : EntityFrameworkCoreBaseRepository<PasswordResetEntity>, IPasswordResetRepository
    {
        private readonly StoreDbContext _dbContext;
        public PasswordResetRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task AddPasswordResetRequestAsync(PasswordResetEntity entity, CancellationToken cancellation)
        {
            await _dbContext
                .Set<PasswordResetEntity>()
                .AddAsync(entity, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }
        /// <inheritdoc/>
        public async Task<PasswordResetEntity> GetRequestAsync(string resetCode)
        {
            return _dbContext
                .Set<PasswordResetEntity>()
                .FirstOrDefault(r => r.ResetCode == resetCode);
        }

        /// <inheritdoc/>
        public async Task RemovePasswordResetRequestAsync(PasswordResetRequest request, CancellationToken cancellation)
        {
            await _dbContext
                .Set<PasswordResetEntity>()
                .Where(r => r.Id == request.Id)
                .ExecuteDeleteAsync(cancellation);
        }
    }
}
