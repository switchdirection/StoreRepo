using Contracts.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Users
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellation);
        Task<IdentityResult> AddUser(string name, string email, string password, CancellationToken cancellation);
        Task<IdentityResult> AddUser(string name, string email, string password, string phoneNumber, CancellationToken cancellation);
        Task<IdentityResult> EditUser(int id, string name, string email, List<string> roles, CancellationToken cancellation);
        Task<IdentityResult> EditUser(int id, string name, string email, string phoneNumber, List<string> roles, CancellationToken cancellation);

        Task CreateAdminUser(CancellationToken cancellation);
        Task<IdentityResult> DeleteUser(int id);
    }
}
