using Application.Category.Model;
using Application.Category.Repository;
using Contracts.Games;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Category.Repository
{
    /// <summary>
    /// Репозиторий по работе с категориями
    /// </summary>
    public sealed class CategoryRepository : EntityFrameworkCoreBaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellation)
        {
            return _dbContext.Set<CategoryEntity>().Include(g => g.GameId).ToListAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task<CategoryEntity> GetCategoryByIdAsync(int id, CancellationToken cancellation)
        {
            return await _dbContext.Set<CategoryEntity>().FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        /// <inheritdoc/>
        public async Task<bool> AddCategoryAsync(CategoryEntity category, CancellationToken cancellation)
        {
            try
            {
                await _dbContext.Set<CategoryEntity>().AddAsync(category, cancellation);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                .Set<CategoryEntity>()
                .Where(c => c.CategoryId == categoryId)
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
        public async Task<bool> EditCategoryAsync(EditCategoryModel model, CancellationToken cancellation)
        {
            try
            {
                await _dbContext
                .Set<CategoryEntity>()
                .Where(c => c.CategoryId == model.CategoryId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.CategoryName, model.CategoryName));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
