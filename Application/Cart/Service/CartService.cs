using Application.Cart.Repository;
using Contracts.Cart;
using Domain.Entities;

namespace Application.Cart.Service
{
    /// <inheritdoc/>
    public sealed class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(
            ICartRepository cartRepository
            )
        {
            _cartRepository = cartRepository;
        }
        /// <inheritdoc/>
        public async Task<bool> AddGameToCart(int gameId, ApplicationUser user, CancellationToken cancellation)
        {
           await _cartRepository.AddGameToCart(gameId, user, cancellation);
            return true;
        }
        /// <inheritdoc/>
        public async Task DeleteAllItems(CartEntity cart, CancellationToken cancellation)
        {
            await _cartRepository.DeleteAllItems(cart, cancellation);
        }
        /// <inheritdoc/>
        public async Task DeleteItem(int gameId, CartEntity cart, CancellationToken cancellation)
        {
            await _cartRepository.DeleteItem(gameId, cart, cancellation);
        }
        /// <inheritdoc/>
        public async Task<CartEntity> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return await _cartRepository.GetByIdAsync(id, cancellation);
        }
        /// <inheritdoc/>
        public async Task<List<CartItemDto>> GetCartItems(ApplicationUser user, CancellationToken cancellation)
        {
            var cartId = user.CartId;
            return await _cartRepository.GetCartItems(cartId, cancellation);
        }
    }
}
