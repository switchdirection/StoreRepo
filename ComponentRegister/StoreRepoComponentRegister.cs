using DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentRegister
{
    public sealed class StoreRepoComponentRegister
    {
        public static void AddComponents(IServiceCollection services, IConfiguration configuration)
        {
            RegisterRepositories(services, configuration);
            RegisterServices(services, configuration);
        }

        public static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
