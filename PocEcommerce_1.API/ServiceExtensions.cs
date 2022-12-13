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
    }
}
