using Application.Roles.Repository;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Roles
{
    /// <summary>
    /// Репозиторий по работе с ролями
    /// </summary>
    public sealed class RoleRepository : EntityFrameworkCoreBaseRepository<ApplicationRole>, IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly StoreDbContext _dbContext;
        public RoleRepository(
            StoreDbContext dbContext,
            RoleManager<ApplicationRole> roleManager
            ) : base(dbContext)
        {
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task AddRoleAsync(string roleName)
        {
            try
            {
                if (!string.IsNullOrEmpty(roleName) && !await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = roleName
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <inheritdoc/>
        public async Task CreateBaseRolesAsync(CancellationToken cancellation)
        {
            var roles = new[] { "admin", "moderator", "user" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole() { Name = role });
                }
            }
        }

        /// <inheritdoc/>
        public async Task DeleteRoleAsync(int id, CancellationToken cancellation)
        {
            try
            {
                ApplicationRole? role = await _roleManager.FindByIdAsync(id.ToString());
                await _roleManager.DeleteAsync(role);
            }
            catch(NullReferenceException ex)
            {
                throw new NullReferenceException($"Ошибка RoleRepository/DeleteRole: {ex.Message}");
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ошибка: {ex.Message}");
            }
            
        }

        /// <inheritdoc/>
        public List<ApplicationRole> GetAllRolesAsync(CancellationToken cancellation)
        {
            return _roleManager.Roles.ToList();
        }

        /// <inheritdoc/>
        public async Task<ApplicationRole> GetRoleByIdAsync(int id, CancellationToken cancellation)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }
    }
}
