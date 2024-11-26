using Application.Platforms.Repository;
using Application.Platforms.Model;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Platforms.Repository
{
    /// <summary>
    /// Репозиторий по работе с платформами
    /// </summary>
    public sealed class PlatformRepository : EntityFrameworkCoreBaseRepository<PlatformEntity>, IPlatformRepository
    {
        private readonly StoreDbContext _dbContext;
        public PlatformRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<PlatformEntity> GeetPlatformByIdAsync(int id, CancellationToken cancellation)
        {
            return _dbContext
                .Platforms
                .FirstOrDefault(p => p.PlatformId == id);
        }

        /// <inheritdoc/>
        public async Task<List<PlatformEntity>> GetAllPlatformsAsync(CancellationToken cancellation)
        {
            return await _dbContext.Platforms.ToListAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> DeletePlatformAsync(int platformId, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<PlatformEntity>()
                    .Where(p => p.PlatformId == platformId)
                    .ExecuteDeleteAsync(cancellation);
                await _dbContext.SaveChangesAsync(cancellation);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EditPlatformAsync(EditPlatformModel model, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<PlatformEntity>()
                    .Where(p => p.PlatformId == model.PlatformId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(p => p.PlatformName, model.PlatformName), cancellation);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> AddPlatformAsync(string platformName, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<PlatformEntity>()
                    .AddAsync(new PlatformEntity 
                    { 
                        PlatformName = platformName
                    }, cancellation); 
                await _dbContext.SaveChangesAsync(cancellation);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
