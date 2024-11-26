using Microsoft.AspNetCore.Mvc;
using Application.PasswordReset.Service;

namespace StoreRepo.Controllers
{
    /// <summary>
    /// Контроллер по взаимодействию с паролем пользователя
    /// </summary>
    public class PasswordController : Controller
    {
        private readonly IPasswordResetService _passwordResetService;

        public PasswordController(IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }
        /// <summary>
        /// Метод перенаправляющий на страницу с вводом email-ла для отправки кода
        /// </summary>
        public IActionResult ChangePasswordView()
        {
            return View("PasswordView");
        }
        /// <summary>
        /// Метод перенаправляющий на страницу ввода кода для подтверждение email-а и сброса пароля
        /// </summary>
        public IActionResult ConfirmEmail()
        {
            return View("ConfirmEmailView");
        }
        /// <summary>
        /// Метод контроллера для отправки сообщения с кодом для сброса
        /// </summary>
        /// <param name="userEmail">Почта пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> FindEmail(string userEmail, CancellationToken cancellation)
        {
            var result = await _passwordResetService.GenerateAndSendResetCodeAsync(userEmail, cancellation);

            return RedirectToAction("ConfirmEmail");
        }
        /// <summary>
        /// Метод контроллера проверяющий корректность введённого кода сброса, сбрасывает пароль и отправляет сообщение пользователю
        /// </summary>
        /// <param name="resetCode">Код сброса</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string resetCode, CancellationToken cancellation)
        {
            var result = await _passwordResetService.ResetUserPasswordAsync(resetCode, cancellation);
            if (result)
            {
                TempData["DropPasswordSuccess"] = "Пароль был успешно сброшен. Новый пароль был отправлен на почту";
            }
            else
            {
                TempData["DropPasswordError"] = "Пароль не был сброшен";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
