using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Business;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.Context;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.Data.Repositories;
using PocEcommerce_1.Data.UnitOfWork;
using PocEcommerce_1.Services;
using PocEcommerce_1.Services.Interfaces;

namespace PocEcommerce_1.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthSevice>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ICoursetService, ProductService>();
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IOrderBusiness, ShoppingCartBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, ShoppingCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}