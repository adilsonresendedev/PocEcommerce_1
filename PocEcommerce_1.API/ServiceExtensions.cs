using PocEcommerce_1.Services;
using PocEcommerce_1.Services.Interfaces;

namespace PocEcommerce_1.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthSevice>();
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
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