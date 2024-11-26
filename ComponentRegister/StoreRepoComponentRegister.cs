using Application.Common;
using Application.Games;
using Application.Category;
using DataAccess.Cart;
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
using Application.Users;
using Application.Developers.Repository;
using DataAccess.Developers.Repository;
using Application.Publishers.Repository;
using DataAccess.Publishers.Repository;
using Application.Platforms.Repository;
using DataAccess.Platforms.Repository;
using DataAccess.Orders.Repository;
using Application.Developers.Service;
using Application.Publishers.Service;
using Application.Platforms.Service;
using Application.Cart.Service;
using Application.Cart.Repository;
using Application.Orders.Service;
using Application.Orders.Repository;
using Application.OrdersHistory.Repository;
using DataAccess.OrdersHistory.Repository;
using Application.OrdersHistory.Service;
using Application.PasswordReset.Repository;
using DataAccess.PasswordReset.Repository;
using Application.PasswordReset.Service;
using Application.Email.Service;

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
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrdersHistoryRepository, OrdersHistoryRepository>();
            services.AddScoped<IPasswordResetRepository, PasswordResetRepository>();
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            services.AddScoped<IGamesService, GameService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<RoleManager<ApplicationRole>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrdersHistoryService, OrdersHistoryService>();
            services.AddScoped<IPasswordResetService, PasswordResetService>();
            services.AddScoped<IEmailService, EmailService>();

        }

        private static void RegisterMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GameMapperProfile());
                mc.AddProfile(new CategoryMapperProfile());
                mc.AddProfile(new DeveloperMapperProfile());
                mc.AddProfile(new PublisherMapperProfile());
                mc.AddProfile(new PlatformMapperProfile());
                mc.AddProfile(new OrdersHistoryMapperProfile());
                mc.AddProfile(new OrderMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
