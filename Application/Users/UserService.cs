using Application.Cart.Repository;
using Application.Roles.Services;
using Contracts.Requests;
using Contracts.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    /// <summary>
    /// Сервис по работе с пользователем
    /// </summary>
    public sealed class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRoleService _roleService;
        private readonly ICartRepository _cartRepository;
        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IRoleService roleService,
            ICartRepository cartRepository
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
            _cartRepository = cartRepository;
            
        }
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task CreateAdminUserAsync(CancellationToken cancellation)
        {
            
            await _roleService.CreateBaseRolesAsync(cancellation);
            string userName = "admin";
            string email = "admin@admin.com";
            string password = "Test123!";
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = email
                };
                await _userManager.CreateAsync(user, password);

                await _userManager.AddToRoleAsync(user, "admin");
            }
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> AddUserAsync(string name, string email, string password, CancellationToken cancellation)
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

        /// <inheritdoc/>
        public async Task<IdentityResult> AddUserAsync(string name, string email, string password, string phoneNumber, CancellationToken cancellation)
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

        /// <inheritdoc/>
        public async Task<IdentityResult> DeleteUserAsync(int id)
        {
           var user = await _userManager.FindByIdAsync(id.ToString());
           return await _userManager.DeleteAsync(user);
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> EditUserAsync(int id, string name, string email, List<string> roles, CancellationToken cancellation)
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

        /// <inheritdoc/>
        public async Task<IdentityResult> EditUserAsync(int id, string name, string email, string phoneNumber, List<string> roles, CancellationToken cancellation)
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

                await _userManager.AddToRolesAsync(user, rolesToAdd);
                await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                var result = await _userManager.UpdateAsync(user);

                return result;
            }
            else
            {
                throw new Exception("user == null, /UserService.cs/EditUser");
            }
        }

        /// <inheritdoc/>
        public async Task AddCartToUserAsync(string userId, CancellationToken cancellation)
        {
            await _cartRepository.AddCartToUserAsync(userId, cancellation);
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ChangeUserNameAsync(int userId, string userName, CancellationToken cancellation)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                user.UserName = userName;
                result = await _userManager.UpdateAsync(user);
                return result;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ChangeEmailAsync(int userId, string email, CancellationToken cancellation)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                user.Email = email;
                result = await _userManager.UpdateAsync(user);
                return result;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ChangePhoneNumberAsync(int userId, string phoneNumber, CancellationToken cancellation)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                user.PhoneNumber = phoneNumber;
                result = await _userManager.UpdateAsync(user);
                return result;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordRequest request, int userId, CancellationToken cancellation)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                result = await _userManager.ResetPasswordAsync(user, resetToken, request.newPassword);
                return result;
            }
            catch (NullReferenceException ex) 
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return result;
            }
        }
    }
}
