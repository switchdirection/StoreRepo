using Application.Common;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Common
{
    public class EntityFrameworkCoreBaseRepository<T> : IRepository<T> where T : class
    {
        private readonly StoreDbContext _dbContext;
        public EntityFrameworkCoreBaseRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _dbContext.FindAsync<T>(id).AsTask();
        }
    }
}
