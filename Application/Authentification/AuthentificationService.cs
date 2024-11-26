using Domain.Entities;
using Microsoft.AspNetCore.Identity;

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

        /// <inheritdoc/>
        public async Task<IdentityResult> RegisterAsync(string username, string email, string password, CancellationToken cancellation)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                RegistrationDate = DateTime.UtcNow,
                Cart = new CartEntity()
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
