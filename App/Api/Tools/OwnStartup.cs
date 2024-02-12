using Database;
using Microsoft.EntityFrameworkCore;
using Shared.Registration;
using Services;

namespace Api.Tools
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSharedRegistration();
            builder.Services.AddDbContext<CachedContext>(op => op.UseInMemoryDatabase("Cache"));
            builder.Services.AddInternalServices();
        }

        public static void UseConfiguration(this WebApplication _)
        {
            // No need to use anything here
        }
    }
}
