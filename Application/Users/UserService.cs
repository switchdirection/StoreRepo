using Application.Roles.Services;
using Contracts.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRoleService _roleService;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IRoleService roleService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
            
        }
        public async Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellation)
        {
            var users = await _userManager.Users.ToListAsync(cancellation);
			var usersDto = new List<UserDto>();
			foreach (var user in users)
			{
                var userRole = await _userManager.GetRolesAsync(user);
				usersDto.Add(new UserDto
				{
					Id = user.Id,
					Name = user.UserName,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
                    Roles = userRole
				});
			}
            return usersDto;
		}

        public async Task CreateAdminUser(CancellationToken cancellation)
        {
            
            await _roleService.CreateBaseRoles(cancellation);
            string email = "admin@admin.com";
            string password = "Test123!";
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = email,
                    Email = email
                };
                await _userManager.CreateAsync(user, password);

                await _userManager.AddToRoleAsync(user, "admin");
            }
        }

        public async Task<IdentityResult> AddUser(string name, string email, string password, CancellationToken cancellation)
        {
            var user = new ApplicationUser
            {
                UserName = name,
                Email = email,
            };

            var role = await _roleManager.FindByNameAsync("user");

            await _userManager.CreateAsync(user, password);

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            return result;
        }

        public async Task<IdentityResult> AddUser(string name, string email, string password, string phoneNumber, CancellationToken cancellation)
        {
            var user = new ApplicationUser
            {
                UserName = name,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            var role = await _roleManager.FindByNameAsync("user");

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
                
            }
            await _userManager.AddToRoleAsync(user, role.Name);
            return result;

        }

        public async Task<IdentityResult> DeleteUser(int id)
        {
           var user = await _userManager.FindByIdAsync(id.ToString());
           return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> EditUser(int id, string name, string email, List<string> roles, CancellationToken cancellation)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.UserName = name;
                user.Email = email;


                var userRoles = _userManager.GetRolesAsync(user).Result;
                var rolesToAdd = roles.Except(userRoles);
                var rolesToRemove = userRoles.Except(roles);

                _userManager.AddToRolesAsync(user, rolesToAdd).Wait();
                _userManager.RemoveFromRolesAsync(user, rolesToRemove).Wait();
                var result = await _userManager.UpdateAsync(user);

                return result;
            }
            else
            {
                throw new Exception("user == null, /UserService.cs/EditUser");
            }
        }

        public async Task<IdentityResult> EditUser(int id, string name, string email, string phoneNumber, List<string> roles, CancellationToken cancellation)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.UserName = name;
                user.Email = email;
                user.PhoneNumber = phoneNumber;

                var userRoles = _userManager.GetRolesAsync(user).Result;
                var rolesToAdd = roles.Except(userRoles);
                var rolesToRemove = userRoles.Except(roles);

                _userManager.AddToRolesAsync(user, rolesToAdd).Wait();
                _userManager.RemoveFromRolesAsync(user, rolesToRemove).Wait();
                var result = await _userManager.UpdateAsync(user);

                return result;
            }
            else
            {
                throw new Exception("user == null, /UserService.cs/EditUser");
            }
        }
    }
}
