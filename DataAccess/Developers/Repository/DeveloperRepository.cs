using Application.Developers.Repository;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Developers.Model;

namespace DataAccess.Developers.Repository
{
    /// <summary>
    /// Репозиторий по работе с разработчиками
    /// </summary>
    public sealed class DeveloperRepository : EntityFrameworkCoreBaseRepository<DeveloperEntity>, IDeveloperRepository
    {
        private readonly StoreDbContext _dbContext;
        public DeveloperRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<List<DeveloperEntity>> GetAllDevelopersAsync(CancellationToken cancellationToken)
        {
            return await _dbContext
                .Set<DeveloperEntity>()
                .ToListAsync(cancellationToken);  
        }

        /// <inheritdoc/>
        public async Task<bool> AddDeveloperAsync(DeveloperEntity entity, CancellationToken cancellation)
        {
            await _dbContext.Set<DeveloperEntity>().AddAsync(entity, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
            return true;
        }

        /// <inheritdoc/>
        public async Task<DeveloperEntity> GetDeveloperByIdAsync(int id, CancellationToken cancellation)
        {
            return _dbContext.Developers
                .FirstOrDefault(d => d.DeveloperId == id);
        }

        /// <inheritdoc/>
        public async Task DeleteDeveloperAsync(int developerId, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<DeveloperEntity>()
                    .Where(d => d.DeveloperId == developerId)
                    .ExecuteDeleteAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task EditDeveloperAsync(EditDeveloperModel model, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<DeveloperEntity>()
                    .Where(d => d.DeveloperId == model.DeveloperId)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(d => d.DeveloperName, model.DeveloperName)
                    .SetProperty(d => d.WebsiteUrl, model.DeveloperUrl), cancellation);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task AddDeveloperByRequestAsync(DeveloperEntity entity, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<DeveloperEntity>()
                    .AddAsync(entity, cancellation);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
