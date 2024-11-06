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
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Application.Authentification;
using Application.Images.Services;
using Application.Images.Repositories;
using DataAccess.Images;
using Application.Roles.Services;
using Application.Roles.Repository;
using DataAccess.Roles;

namespace ComponentRegister
{
    /// <summary>
    /// Класс регистрации компонентов приложения
    /// </summary>
    public sealed class StoreRepoComponentRegister
    {
        public static void AddComponents(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddDefaultTokenProviders();

            

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
            }, ServiceLifetime.Scoped);

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            services.AddScoped<IGamesService, GameService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<RoleManager<ApplicationRole>>();

        }

        private static void RegisterMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GameMapperProfile());
                mc.AddProfile(new CategoryMapperProfile());
                //mc.AddProfile(new RoleMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
