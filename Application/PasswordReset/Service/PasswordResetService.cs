using Application.Email.Service;
using Application.PasswordReset.Repository;
using Contracts.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.PasswordReset.Service
{
    /// <summary>
    /// Сервис для сброса пароля
    /// </summary>
    public sealed class PasswordResetService : IPasswordResetService
    {
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        public PasswordResetService(IPasswordResetRepository passwordResetRepository,
            UserManager<ApplicationUser> userManager,
            IEmailService emailService)
        {
            _passwordResetRepository = passwordResetRepository;
            _userManager = userManager;
            _emailService = emailService;

        }
        /// <inheritdoc/>
        public async Task<bool> GenerateAndSendResetCodeAsync(string userEmail, CancellationToken cancellation)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                throw new Exception("Пользователь не был найден.");
            }
            var resetCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            var expirationTime = DateTime.UtcNow.AddMinutes(15);
            await _passwordResetRepository.AddPasswordResetRequestAsync(new PasswordResetEntity
            {
                Email = userEmail,
                ResetCode = resetCode,
                ExpirationTime = expirationTime
            }, cancellation);

            string subject = "Сброс пароля на сайте SteamMarket";
            string body = $"Ваш код для сброса пароля: {resetCode}\n\nЕсли это были не вы - игнорируйте это сообщение!";

            _emailService.SendEmail(subject, body, user);
            return true;
        }
        /// <inheritdoc/>
        public async Task<bool> ResetUserPasswordAsync(string resetCode, CancellationToken cancellation)
        {
            // Проверка кода восстановления
            var request = await _passwordResetRepository.GetRequestAsync(resetCode.Trim());

            if (request == null || request.ExpirationTime < DateTime.UtcNow)
            {
                throw new Exception("Неверный или истёкший код.");
            }

            // Найдите пользователя и обновите пароль
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Пользователь не найден.");
            }
            string newPassword = Guid.NewGuid().ToString().Substring(0, 12).ToLower();
            newPassword += Guid.NewGuid().ToString().Substring(0, 12).ToUpper() + "@";
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception($"Не удалось обновить пароль. {result.Errors}");
            }

            string subject = "Сброс пароля на сайте SteamMarket";
            string body = $"Ваш новый пароль для входа в аккаунт на сайте SteamMarket: {newPassword}\n\nНикому его не показывайте и не распространяйте!";

            _emailService.SendEmail(subject, body, user);

            // Удалите запрос восстановления
            await _passwordResetRepository.RemovePasswordResetRequestAsync(new PasswordResetRequest
            {
                Id = request.Id,
                Email = request.Email,
                ResetCode = request.ResetCode,
                ExpirationTime = request.ExpirationTime
            }, cancellation);
            return true;
        }
    }
}
