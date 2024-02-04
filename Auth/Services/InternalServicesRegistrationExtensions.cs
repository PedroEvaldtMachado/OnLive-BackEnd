using Microsoft.Extensions.DependencyInjection;
using Services.Implementations.Users;
using Services.Users;

namespace Services
{
    public static class InternalServicesRegistrationExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
