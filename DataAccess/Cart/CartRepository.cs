using Application.Cart.Repository;
using Application.Common;
using Application.Games.Repositories;
using Contracts.Cart;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Cart
{
    /// <summary>
    /// Репозиторий по работе с корзиной
    /// </summary>
    public sealed class CartRepository : EntityFrameworkCoreBaseRepository<CartEntity>, ICartRepository
    {
        private readonly StoreDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGameRepository _gameRepository;
        public CartRepository(
            StoreDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IGameRepository gameRepository
            ) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _gameRepository = gameRepository;

        }
        /// <inheritdoc/>
        public async Task AddCartToUserAsync(string userId, CancellationToken cancellation)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user.Cart == null)
            {
                user.Cart = new CartEntity
                {
                    UserId = user.Id
                };
            }
            await _dbContext.SaveChangesAsync();
            user.CartId = user.Cart.Id;
            await _userManager.UpdateAsync(user);
        }
        /// <inheritdoc/>
        public async Task AddGameToCart(int gameId, ApplicationUser user, CancellationToken cancellation)
        {
            var game = await _gameRepository.GetGameByIdASync(gameId, cancellation);
            user.Cart.Games.Add(game);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        /// <inheritdoc/>
        public async Task<List<CartItemDto>> GetCartItems(int cartId, CancellationToken cancellation)
        {
            var cart = await GetByIdAsync(cartId);
            List<CartItemDto> items = new List<CartItemDto>(cart.Games.Count);
            foreach (var game in cart.Games)
            {
                items.Add(new CartItemDto
                {
                    Id = game.Id,
                    Name = game.Title,
                    Price = game.Price,
                    StockQuantity = game.StockQuantity,
                    MainImageUrl = game.Images.FirstOrDefault()?.ImageUrl
                });
            }
            return items;
        }
        /// <inheritdoc/>
        public async Task<CartEntity> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return _dbContext
                .Set<CartEntity>()
                .Include(c => c.Games)
                .ThenInclude(g => g.Images)
                .FirstOrDefault(x => x.Id == id);
        }
        /// <inheritdoc/>
        public async Task DeleteItem(int gameId, CartEntity cart, CancellationToken cancellation)
        {
            cart.Games.Remove(await _gameRepository.GetElementByIdAsync(gameId));
            await _dbContext.SaveChangesAsync();
        }
        /// <inheritdoc/>
        public async Task DeleteAllItems(CartEntity cart, CancellationToken cancellation)
        {
            cart.Games.Clear();
            await _dbContext.SaveChangesAsync();
        }
    }
    
}
