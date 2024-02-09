using Microsoft.Extensions.DependencyInjection;
using Services.Implementations.Messages;
using Services.Messages;
using Shared.Infra;

namespace Services
{
    public static class InternalServicesRegistrationExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IBuilder<IMessageService>, MessageServiceBuilder>();

            return services;
        }
    }
}
