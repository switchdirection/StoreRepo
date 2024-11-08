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

        public async Task ChangeVisibility(int gameId, CancellationToken cancellation)
        {
            var game = await _dbContext.Set<GameEntity>().FindAsync(gameId);
            if (game.IsDeleted)
            {
                game.IsDeleted = false;
            }
            else
            {
                game.IsDeleted = true;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int gameId, CancellationToken cancellation)
        {
            await _dbContext.Set<GameEntity>().Where(g => g.Id == gameId).ExecuteDeleteAsync(cancellation);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<GameEntity>> GetAllGamesAsync()
        {
            return _dbContext.Set<GameEntity>().Include(c => c.Categories).ThenInclude(c => c.GameId).ThenInclude(c => c.Images).ToListAsync();
            
        }

        public Task<GameEntity> GetElementById(int id)
        {
            return _dbContext.Set<GameEntity>().FindAsync(id).AsTask();
        }

        public async Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation)
        {
            return _dbContext.Set<GameEntity>().Include(c => c.Categories).ThenInclude(c => c.GameId).ThenInclude(c => c.Images).FirstOrDefault(g => g.Id == id);
        }
    }
}
