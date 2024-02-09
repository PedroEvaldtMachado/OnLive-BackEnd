using Microsoft.Extensions.DependencyInjection;
using Querys.Implementations.Messages;
using Querys.Messages;
using Shared.Infra;

namespace Querys
{
    public static class InternalQuerysRegistrationExtensions
    {
        public static IServiceCollection AddInternalQuerys(this IServiceCollection services)
        {
            services.AddScoped<IBuilder<IMessageQuery>, MessageQueryBuilder>();

            return services;
        }
    }
}
