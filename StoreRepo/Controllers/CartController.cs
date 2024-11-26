using Application.Cart.Service;
using Application.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер корзины
    /// </summary>
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        public CartController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            ICartService cartService
            )
        {
            _userManager = userManager;
            _userService = userService;
            _cartService = cartService;
        }
        /// <summary>
        /// Метод контроллера отображающий корзину пользователя
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> ShowCart(CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            
            if(user.CartId==0)
            {
                await _userService.AddCartToUserAsync(user.Id.ToString(), cancellation);
            }
            
            var cart = await _cartService.GetByIdAsync(user.CartId, cancellation);
            user.Cart = cart;

            var items = await _cartService.GetCartItems(user, cancellation);

            return View("CartView", items);
        }
        /// <summary>
        /// Метод контроллера для удаления игры из корзины
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int gameId, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _cartService.GetByIdAsync(user.CartId, cancellation);
            await _cartService.DeleteItem(gameId, cart, cancellation);
            return RedirectToAction("ShowCart");
        }
        /// <summary>
        /// Метод контроллера для очистки корзины
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        [HttpGet]
        public async Task<IActionResult> DeleteAllFromCart(CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _cartService.GetByIdAsync(user.CartId, cancellation);
            await _cartService.DeleteAllItems(cart, cancellation);
            return RedirectToAction("ShowCart");
        }
    }
}
