using Application.Authentification;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер аутентификации поьзовател
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAuthentificationService _authentificationService;

        public AccountController( IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }
        public IActionResult Login()
        {
            return PartialView("_LoginPartial");
        }

        /// <summary>
        /// Осуществляет аутентификацию и авторизацию пользователя
        /// </summary>
        /// <param name="model">Данные для входа</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellation)
        {
            if(await _authentificationService.SignInAsync(model.Username ,model.Email, model.Password, cancellation))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attemp");
            return View();
        }

        public async Task<IActionResult> Logout(CancellationToken cancellation)
        {
            await _authentificationService.SignOutAsync(cancellation);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("_RegisterPartial");
        }

        public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellation)
        {
            var result = await _authentificationService.RegisterAsync(model.Username, model.Email, model.Password, cancellation);
            if (result.Succeeded)
            {
                await _authentificationService.SignInAsync(model.Username, model.Email, model.Password, cancellation);
                return RedirectToAction("Index", "Home");
            }

            var errors = result.Errors?.Select(x => x.Description).ToList() ?? [];
            return PartialView("_RegisterPartial", 
                new RegisterViewModel 
                { 
                    Errors = errors 
                });
        }
    }
}
