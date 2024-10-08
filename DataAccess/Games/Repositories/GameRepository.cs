using Application.Games.Repositories;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Games.Repositories
{
    public sealed class GameRepository : EntityFrameworkCoreBaseRepository<GameEntity>, IGameRepository
    {
        private readonly StoreDbContext _dbContext;
        public GameRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GameEntity>> GetAllGamesAsync()
        {
            return _dbContext.Set<GameEntity>().Include(c => c.Categories).ThenInclude(c => c.GameId).ToListAsync();
            
        }

        public Task<GameEntity> GetElementById(int id)
        {
            return _dbContext.Set<GameEntity>().FindAsync(id).AsTask();
        }
    }
}
