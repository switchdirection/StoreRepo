using Contracts.Requests;
using Contracts.Users;
using Microsoft.AspNetCore.Identity;

namespace Application.Users
{
    /// <summary>
    /// Интерфейс сервиса по работе с пользователями
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Метод для получчения списка всех пользователей в виде транспортной модели
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> AddUserAsync(string name, string email, string password, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления пользователя с указанием номера телефона
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> AddUserAsync(string name, string email, string password, string phoneNumber, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="roles">Список ролей</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> EditUserAsync(int id, string name, string email, List<string> roles, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования пользователя с указанием номера телефона
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="roles">Список ролей</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> EditUserAsync(int id, string name, string email, string phoneNumber, List<string> roles, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования имени пользователя
        /// </summary>
        /// <param name="userId">Идентификатор</param>
        /// <param name="userName">Новое имя пользователя</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IdentityResult> ChangeUserNameAsync(int userId, string userName, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования электронной почты пользователя
        /// </summary>
        /// <param name="userId">Идентификатор</param>
        /// <param name="email">Новый адрес электронной почты</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> ChangeEmailAsync(int userId, string email, CancellationToken cancellation);
        /// <summary>
        /// Метод для редактирования номера телефона
        /// </summary>
        /// <param name="userId">Идентификатор</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> ChangePhoneNumberAsync(int userId, string phoneNumber, CancellationToken cancellation);
        /// <summary>
        /// Метод для изменения пароля пользователя по запросу
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="userId">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordRequest request, int userId, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления корзины пользователю
        /// </summary>
        /// <param name="userId">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddCartToUserAsync(string userId, CancellationToken cancellation);
        /// <summary>
        /// Метод для создания администратора
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task CreateAdminUserAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        Task<IdentityResult> DeleteUserAsync(int id);
    }
}
