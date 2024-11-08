using Application.Category.Repository;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Category.Repository
{
    public sealed class CategoryRepository : EntityFrameworkCoreBaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<CategoryEntity>> GetAllCategories()
        {
            return _dbContext.Set<CategoryEntity>().Include(g => g.GameId).ToListAsync();
        }

        public Task GetCategoryByGameId(int gameId)
        {
            return Task.CompletedTask;
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _dbContext.Set<CategoryEntity>().FirstOrDefaultAsync(c => c.CategoryId == id);
        }
    }
}
