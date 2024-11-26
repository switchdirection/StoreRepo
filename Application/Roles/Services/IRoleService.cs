using Contracts.Roles;
using Domain.Entities;

namespace Application.Roles.Services
{
    /// <summary>
    /// Интерфейс сервиса для работе с ролями
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Метод для получения всех ролей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        List<RoleDto> GetAllRolesAsync(CancellationToken cancellation);
        /// <summary>
        /// Метод для получения роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<ApplicationRole> GetRoleByIdAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления роли
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteRoleAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления роля
        /// </summary>
        /// <param name="roleName">Роль</param>
        /// <param name="cancellation">Токен отмены</param>
        Task AddRoleAsync(string roleName);
        /// <summary>
        /// Метод для создания всех базовых ролей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        Task CreateBaseRolesAsync(CancellationToken cancellation);
    }
}
