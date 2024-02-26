using Database;
using Microsoft.EntityFrameworkCore;
using Shared.Registration;
using Services;

namespace Api.Tools
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this IServiceCollection builder)
        {
            builder.AddDistributedMemoryCache();

            builder.AddSharedRegistration();
            builder.AddDbContext<CachedContext>(op => op.UseInMemoryDatabase("Cache"));
            builder.AddInternalServices();
        }

        public static void UseConfiguration(this WebApplication _)
        {
            // No need to use anything here
        }
    }
}
