using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;

namespace Services
{
    public static class InternalServicesRegistrationExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IStreamService, StreamService>();

            return services;
        }
    }
}
