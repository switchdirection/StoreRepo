using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Infastructure.HashPassword;

namespace Application.Authentification
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public sealed class AuthentificationService : IAuthentificationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthentificationService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task CheckAdminUser()
        {

            var roles = new[] { "admin", "moderator", "user" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole() { Name = role});
                }
            }

            string email = "admin@admin.com";
            string password = "Test123!";
            if(await _userManager.FindByEmailAsync(email) == null)
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

        /// <inheritdoc/>
        public async Task<IdentityResult> RegisterAsync(string username, string email, string password, CancellationToken cancellation)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                
            };

            var role = await _roleManager.FindByNameAsync("user");

            await _userManager.CreateAsync(user, password);

            return await _userManager.AddToRoleAsync(user, role.Name);
        }

        /// <inheritdoc/>
        public async Task<bool> SignInAsync(string username, string email, string password, CancellationToken cancellation)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new UnauthorizedAccessException("Неправильно введён email");

            var isPasswordMatch = await _userManager.CheckPasswordAsync(user, password);
            if (isPasswordMatch)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public Task SignOutAsync(CancellationToken cancellation)
        {
            return _signInManager.SignOutAsync();
        }
    }
}
