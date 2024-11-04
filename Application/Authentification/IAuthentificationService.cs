using Microsoft.AspNetCore.Identity;

namespace Application.Authentification
{
    /// <summary>
    /// Интерфейс сервиса атентификации
    /// </summary>
    public interface IAuthentificationService
    {
        Task CheckAdminUser();
        /// <summary>
        /// Метод осуществляющий вход пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task<bool> SignInAsync(string username, string email, string password, CancellationToken cancellation);
        /// <summary>
        /// Метод который осуществляет разлогинивание пользователя
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task SignOutAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод осуществляющий регистрацию пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterAsync(string username, string email, string password, CancellationToken cancellation);
    }
}
