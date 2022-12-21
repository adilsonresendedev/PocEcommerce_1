using PocEcommerce_1.Business;
using PocEcommerce_1.Business.Interfaces;
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
            services.AddScoped<IProductService, ProductService>();
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IShoppingCartBusiness, ShoppingCartBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services;
        }
    }
}