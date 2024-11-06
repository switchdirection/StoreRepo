using Application.Roles.Repository;
using Domain.Entities;

namespace Application.Roles.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        /// <inheritdoc/>
        public Task AddRole(string roleName)
        {
            return _roleRepository.AddRole(roleName);
        }

        /// <inheritdoc/>
        public async Task DeleteRole(int id, CancellationToken cancellation)
        {
            await _roleRepository.DeleteRole(id, cancellation);
        }

        /// <inheritdoc/>
        public List<ApplicationRole> GetAllRoles(CancellationToken cancellation)
        {
            return _roleRepository.GetAllRoles(cancellation);
        }

        public Task<ApplicationRole> GetRoleById(int id, CancellationToken cancellation)
        {
            return _roleRepository.GetRoleById(id, cancellation);
        }
    }
}
