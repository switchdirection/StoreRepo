using Application.Authentification;
using Application.Orders.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreRepo.Models;
using Application.Users.Model;
using Contracts.Requests;
using Application.Users;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер аутентификации пользователя
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAuthentificationService _authentificationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public AccountController( IAuthentificationService authentificationService,
            UserManager<ApplicationUser> userManager,
            IOrderService orderService,
            IUserService userService)
        {
            _authentificationService = authentificationService;
            _userManager = userManager;
            _orderService = orderService;
            _userService = userService;
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
        /// <summary>
        /// Метод контроллера для разлогинивания пользователя
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> Logout(CancellationToken cancellation)
        {
            await _authentificationService.SignOutAsync(cancellation);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Метод контроллера производящий регистрацию пользователя
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("_RegisterPartial");
        }
        /// <summary>
        /// Метод производящий регистрацию пользователя
        /// </summary>
        /// <param name="model">Модель для регистрации пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
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

        /// <summary>
        /// Метод контроллера перенаправляющий пользователя в личный кабинет
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        public async Task<IActionResult> Profile(CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _orderService.GetOrdersByUserIdForViewAsync(user.Id, cancellation);

            return View("ProfileView", new UserProfileViewModel
            {
                Name = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate,
                Orders = orders
            });
        }
        /// <summary>
        /// Метод контроллера для обновления имени пользователя
        /// </summary>
        /// <param name="newUserName">Новое имя пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> UpdateName(string newUserName, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userService.ChangeUserNameAsync(user.Id, newUserName, cancellation);
            if (result.Succeeded)
            {
                TempData["UserNameChangedSuccess"] = "Ваше имя изменено успешно";
            }
            else
            {
                TempData["UserNameChangedError"] = "Ваше имя не было изменено";
            }
            return RedirectToAction("Profile");
        }
        /// <summary>
        /// Метод контроллера для обновления электронной почты пользователя
        /// </summary>
        /// <param name="newEmail">Новый адрес электронной почты</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> UpdateEmail(string newEmail, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userService.ChangeEmailAsync(user.Id, newEmail, cancellation);
            if (result.Succeeded)
            {
                TempData["UserEmailChangedSuccess"] = "Ваш email изменен успешно";
            }
            else
            {
                TempData["UserEmailChangedError"] = "Ваш email не был изменён";

            }
            return RedirectToAction("Profile");
        }
        /// <summary>
        /// Метод контроллера для обновления номера телефона пользователя
        /// </summary>
        /// <param name="newPhoneNumber">Новый номер телефона</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> UpdatePhoneNumber(string newPhoneNumber, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userService.ChangePhoneNumberAsync(user.Id, newPhoneNumber, cancellation);
            if (result.Succeeded)
            {
                TempData["UserPhoneNumberChangedSuccess"] = "Ваш номер телефона изменен успешно";
            }
            else
            {
                TempData["UserPhoneNumberChangedError"] = "Ваш номер телефона не был изменён";
            }
            return RedirectToAction("Profile");
        }
        /// <summary>
        /// Метод контроллера для изменения пароля пользователя
        /// </summary>
        /// <param name="request">Запрос на смену пароля</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request, CancellationToken cancellation)
        {
            var user = await _userManager.GetUserAsync(User);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.currentPassword);
            if(isPasswordCorrect)
            {
                var result = await _userService.ChangePasswordAsync(request, user.Id, cancellation);
                if(result.Succeeded)
                {
                    TempData["UserPasswordChangedSuccess"] = "Ваш пароль изменен успешно";
                }
                else
                {
                    TempData["UserPasswordChangedError"] = $"{result.Errors.First().Description}";
                }
            }
            return RedirectToAction("Profile");
        }
    }
}
