using Application.Publishers.Model;
using Application.Publishers.Repository;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Publishers.Repository
{
    /// <summary>
    /// Репозиторий по работе с издателями
    /// </summary>
    public sealed class PublisherRepository : EntityFrameworkCoreBaseRepository<PublisherEntity>, IPublisherRepository
    {
        private readonly StoreDbContext _dbContext;
        public PublisherRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task AddPublisherByRequestAsync(PublisherEntity entity, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<PublisherEntity>()
                    .AddAsync(entity, cancellation);
                await _dbContext
                    .SaveChangesAsync(cancellation);
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task DeletePublisherAsync(int publisherId, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                    .Set<PublisherEntity>()
                    .Where(p => p.PublisherId == publisherId)
                    .ExecuteDeleteAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task EditPublisherAsync(EditPublisherModel model, CancellationToken cancellation)
        {
            try
            {
                await _dbContext 
                    .Set<PublisherEntity>()
                    .Where(m => m.PublisherId == model.PublisherId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(m => m.PublisherName, model.PublisherName)
                        .SetProperty(m => m.WebsiteUrl, model.PublisherUrl), cancellation);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<List<PublisherEntity>> GetAllPublishersAsync(CancellationToken cancellation)
        {
            return await _dbContext
                .Publishers
                .ToListAsync(cancellation);
        }

        /// <inheritdoc/>
        public Task<PublisherEntity> GetPublisherByIdAsync(int id, CancellationToken cancellation)
        {
            return _dbContext
                .Publishers
                .FirstOrDefaultAsync(p => p.PublisherId == id);
        }
    }
}
