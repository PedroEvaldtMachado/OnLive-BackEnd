using Shared.Registration;
using Domain;
using Database;
using Querys;
using Services;
using Shared.Infra;

namespace Api.Tools
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<DbConnection>(builder.Configuration);
            builder.Services.AddSharedRegistration();
            builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));
            builder.Services.AddInternalQuerys();
            builder.Services.AddInternalServices();
            builder.Services.AddInternalDomain();
        }

        public static void UseConfiguration(this WebApplication _)
        {
            //Future implementation
        }
    }
}
