using Application.Roles.Repository;
using AutoMapper;
using Contracts.Roles;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Roles.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public Task AddRoleAsync(string roleName)
        {
            return _roleRepository.AddRoleAsync(roleName);
        }

        /// <inheritdoc/>
        public async Task DeleteRoleAsync(int id, CancellationToken cancellation)
        {
            await _roleRepository.DeleteRoleAsync(id, cancellation);
        }

        public List<RoleDto> GetAllRolesAsync(CancellationToken cancellation)
        {
            var roles =  _roleRepository.GetAllRolesAsync(cancellation);
            List<RoleDto> rolesDto = new List<RoleDto>(roles.Count);
            foreach (var role in roles)
            {
                rolesDto.Add(new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }
            return rolesDto;
        }

        /// <inheritdoc/>
        public Task<ApplicationRole> GetRoleByIdAsync(int id, CancellationToken cancellation)
        {
            return _roleRepository.GetRoleByIdAsync(id, cancellation);
        }

        /// <inheritdoc/>
        public async Task CreateBaseRolesAsync(CancellationToken cancellation)
        {
            await _roleRepository.CreateBaseRolesAsync(cancellation);
        }
    }
}
