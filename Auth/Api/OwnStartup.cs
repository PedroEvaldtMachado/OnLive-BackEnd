using Querys;
using Services;
using Shared.Infra;
using Shared.Registration;

namespace Api
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSharedRegistration(builder.Configuration.GetSection);
            builder.Services.AddInternalQuerys();
            builder.Services.AddInternalServices();
        }

        public static void UseConfiguration(this WebApplication _)
        {
            //Future implementation
        }
    }
}
