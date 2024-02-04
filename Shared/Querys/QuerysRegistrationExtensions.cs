using Microsoft.Extensions.DependencyInjection;
using Shared.Querys.Implementations;

namespace Shared.Querys
{
    public static class QuerysRegistrationExtensions
    {
        public static IServiceCollection AddQuerys(this IServiceCollection services)
        {
            services.AddScoped(typeof(IQueryCachedParams<>), typeof(QueryCachedParams<>));

            return services;
        }
    }
}
