using Microsoft.Extensions.DependencyInjection;
using Shared.Infra;
using Shared.Querys;
using Shared.Services;

namespace Shared.Registration
{
    public static class SharedRegistrationExtentions
    {
        public static IServiceCollection AddSharedRegistration(this IServiceCollection services)
        {
            InfraRegistration.AddInfra();

            services.AddScoped(typeof(Lazy<>));
            services.AddQuerys();
            services.AddServices();

            return services;
        }
    }
}
