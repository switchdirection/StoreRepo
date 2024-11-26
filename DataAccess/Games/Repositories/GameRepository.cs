using Application.Games.Repositories;
using Contracts.Requests;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Games.Model;
using System.Security.Policy;
using System;

namespace DataAccess.Games.Repositories
{
    /// <summary>
    /// Репозиторий по работе с играми
    /// </summary>
    public sealed class GameRepository : EntityFrameworkCoreBaseRepository<GameEntity>, IGameRepository
    {
        private readonly StoreDbContext _dbContext;
        public GameRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task ChangeVisibilityAsync(int gameId, CancellationToken cancellation)
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

        /// <inheritdoc/>
        public async Task DeleteAsync(int gameId, CancellationToken cancellation)
        {
            await _dbContext.Set<GameEntity>().Where(g => g.Id == gameId).ExecuteDeleteAsync(cancellation);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public Task<List<GameEntity>> GetAllGamesAsync()
        {
            return _dbContext.Set<GameEntity>()
                .Include(g => g.Categories)
                .ThenInclude(c => c.GameId)
                .ThenInclude(c => c.Images)
                .Include(g => g.Developers)
                .Include(p => p.Publishers)
                .Include(p => p.Platforms)
                .AsSplitQuery()
                .ToListAsync();
            
        }

        

        /// <inheritdoc/>
        public async Task<List<GameEntity>> GetAllNotDeletedAsync(GetGamesRequest request, CancellationToken cancellation)
        {
            var query = _dbContext
                .Set<GameEntity>()
                .AsNoTracking()
                .AsQueryable()
                .Where(g => !g.IsDeleted);
                

            query = query
                .OrderBy(g => g.Id)
                .Skip(request.Skip);

            if(request.Take != default)
            {
                query = query.Take(request.Take);
            }

            query = query.Include(g => g.Categories)
                .Include(c => c.Images)
                .Include(g => g.Developers)
                .Include(p => p.Publishers)
                .Include(p => p.Platforms);

            var games = await query
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync(cancellation);
            // Поиск
            if (!string.IsNullOrEmpty(request.Search))
            {
                games = games.Where(g => g.Title.Contains(request.Search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Фильтр по категориям
            if (request.Categories?.Any() == true)
            {
                games = games.Where(g => g.Categories.Any(c => request.Categories.Contains(c.CategoryId))).ToList();
            }

            // Фильтр по цене
            if (request.MinPrice.HasValue)
            {
                games = games.Where(g => g.Price >= request.MinPrice.Value).ToList();
            }

            if (request.MaxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= request.MaxPrice.Value).ToList();
            }

            // Фильтр по разработчикам
            if (request.Developers?.Any() == true)
            {
                games = games.Where(g => g.Developers.Any(d => request.Developers.Contains(d.DeveloperId))).ToList();
            }

            // Фильтр по платформам
            if (request.Platforms?.Any() == true)
            {
                games = games.Where(g => g.Platforms.Any(p => request.Platforms.Contains(p.PlatformId))).ToList();
            }

            // Фильтр по издателям
            if (request.Publishers?.Any() == true)
            {
                games = games.Where(g => g.Publishers.Any(p => request.Publishers.Contains(p.PublisherId))).ToList();
            }

            return games;

        }

        /// <inheritdoc/>
        public Task<GameEntity> GetElementByIdAsync(int id)
        {
            return _dbContext.Set<GameEntity>().FindAsync(id).AsTask();
        }

        /// <inheritdoc/>
        public async Task<GameEntity> GetGameByIdASync(int id, CancellationToken cancellation)
        {
            return _dbContext.Set<GameEntity>()
                .Include(g => g.Categories)
                .Include(g => g.Images)
                .Include(g => g.Developers)
                .Include(p => p.Publishers)
                .Include(p => p.Platforms)
                .AsSplitQuery()
                .FirstOrDefault(g => g.Id == id);
        }

        /// <inheritdoc/>
        public Task<int> GetGamesTotalCountAsync(CancellationToken cancellation)
        {
            return _dbContext.Set<GameEntity>().Where(g =>!g.IsDeleted).CountAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task UpdateGameAsync(GameEditModel model, CancellationToken cancellation)
        {
            var game = _dbContext.Games.
               Include(g => g.Categories)
               .Include(g => g.Developers)
               .Include(p => p.Publishers)
               .Include(p => p.Platforms)
               .FirstOrDefault(g => g.Id == model.Id);
            game.Title = model.Title;
            game.Description = model.Description;
            game.StockQuantity = model.StockQuantity;
            game.Price = model.Price;
            game.Rating = model.Rating;
            game.IsDeleted = model.IsDeleted;
            game.Categories = await _dbContext.Categories.Where(c => model.SelectedCategoryIds.Contains(c.CategoryId)).ToListAsync(cancellation);
            game.Developers = await _dbContext.Developers.Where(c => model.SelectedDeveloperIds.Contains(c.DeveloperId)).ToListAsync(cancellation);
            game.Publishers = await _dbContext.Publishers.Where(c => model.SelectedPublisherIds.Contains(c.PublisherId)).ToListAsync(cancellation);
            game.Platforms = await _dbContext.Platforms.Where(c => model.SelectedPlatformIds.Contains(c.PlatformId)).ToListAsync(cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }
    }
}
