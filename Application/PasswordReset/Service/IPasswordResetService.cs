namespace Application.PasswordReset.Service
{
    /// <summary>
    /// Интерфейс сервиса для сброса пароля
    /// </summary>
    public interface IPasswordResetService
    {
        /// <summary>
        /// Методя для генерации и отправки кодя для сброса пароля
        /// </summary>
        /// <param name="userEmail">Email пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<bool> GenerateAndSendResetCodeAsync(string userEmail, CancellationToken cancellation);
        /// <summary>
        /// Методя для сброса пароля пользователя
        /// </summary>
        /// <param name="resetCode">Код для сброса</param>
        /// <param name="cancellation">токен отмены</param>
        Task<bool> ResetUserPasswordAsync(string resetCode, CancellationToken cancellation);
    }
}
