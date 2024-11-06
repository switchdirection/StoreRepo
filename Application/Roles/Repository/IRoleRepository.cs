using Application.Common;
using Domain.Entities;

namespace Application.Roles.Repository
{
    /// <summary>
    /// Интерфейс репозиторий для работы с ролями
    /// </summary>
    public interface IRoleRepository : IRepository<ApplicationRole>
    {
        /// <summary>
        /// Метод для получения всех ролей
        /// </summary>
        /// <param name="cancellation">Токен отмены</param>
        List<ApplicationRole> GetAllRoles(CancellationToken cancellation);

        /// <summary>
        /// Метод для получения роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation">Токен отмены</param>
        Task<ApplicationRole> GetRoleById(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для удаления роли
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <param name="cancellation">Токен отмены</param>
        Task DeleteRole(int id, CancellationToken cancellation);
        /// <summary>
        /// Метод для добавления роля
        /// </summary>
        /// <param name="roleName">Роль</param>
        /// <param name="cancellation">Токен отмены</param>
        /// <returns></returns>
        Task AddRole(string roleName);

    }
}
