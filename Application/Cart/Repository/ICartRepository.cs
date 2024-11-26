using Application.Common;
using Contracts.Cart;
using Domain.Entities;

namespace Application.Cart.Repository
{
    /// <summary>
    /// Интерфейс репозитория по работе с карзиной
    /// </summary>
    public interface ICartRepository : IRepository<CartEntity>
    {
        /// <summary>
        /// Метод добавления игры в корзину
        /// </summary>
        /// <param name="gameId">Идентификатор игры которую нужно добавить</param>
        /// <param name="user">Пользователь в корзину которого добавляется игра</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddGameToCart(int gameId, ApplicationUser user, CancellationToken cancellation);
        /// <summary>
        /// Метод получения списка игр в конкретной корзине
        /// </summary>
        /// <param name="user">Пользователь которому принадлежит корзина</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<CartItemDto>> GetCartItems(int cartId, CancellationToken cancellation);
        /// <summary>
        /// Метод добавления корзины пользователю
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task AddCartToUserAsync(string userId, CancellationToken cancellation);
        /// <summary>
        /// Метод получения корзину по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор корзины</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<CartEntity> GetByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод удаления игры из корзины
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cart">Корзина из которой нужно удалить игры</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteItem(int gameId, CartEntity cart, CancellationToken cancellation);
        /// <summary>
        /// Метод удаление всех игр из карзины
        /// </summary>
        /// <param name="cart">Корзина которую нужно очистить</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteAllItems(CartEntity cart, CancellationToken cancellation);
    }
}
