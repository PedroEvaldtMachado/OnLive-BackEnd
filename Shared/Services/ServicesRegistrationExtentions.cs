using Microsoft.Extensions.DependencyInjection;

namespace Shared.Services
{
    public static class ServicesRegistrationExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>()

            return services;
        }
    }
}
