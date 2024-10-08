using Application.Common;
using Application.Games;
using Application.Category;
using Application.Games.Repositories;
using AutoMapper;
using DataAccess.Category.Repository;
using DataAccess.Common;
using DataAccess.Games.Repositories;
using Infastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Category.Repository;
using Application.Category.Services;

namespace ComponentRegister
{
    /// <summary>
    /// Класс регистрации компонентов приложения
    /// </summary>
    public sealed class StoreRepoComponentRegister
    {
        public static void AddComponents(IServiceCollection services, IConfiguration configuration)
        {
            RegisterRepositories(services, configuration);
            RegisterServices(services, configuration);
            RegisterMapper(services);
        }

        public static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGamesService, GameService>();
            services.AddScoped<ICategoryService, CategoryService>();

        }

        private static void RegisterMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GameMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
