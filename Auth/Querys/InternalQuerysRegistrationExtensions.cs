using Microsoft.Extensions.DependencyInjection;
using Querys.Implementations.Users;
using Querys.Users;

namespace Querys
{
    public static class InternalQuerysRegistrationExtensions
    {
        public static IServiceCollection AddInternalQuerys(this IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();

            return services;
        }
    }
}
