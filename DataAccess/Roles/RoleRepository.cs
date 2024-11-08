using Application.Roles.Repository;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Roles
{
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

        public async Task AddRole(string roleName)
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

        public async Task CreateBaseRoles(CancellationToken cancellation)
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

        public async Task DeleteRole(int id, CancellationToken cancellation)
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

        public List<ApplicationRole> GetAllRoles(CancellationToken cancellation)
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<ApplicationRole> GetRoleById(int id, CancellationToken cancellation)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }
    }
}
