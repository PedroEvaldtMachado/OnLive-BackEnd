using Shared.Querys;
using Shared.Services;

namespace Api
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(Lazy<>));
            builder.Services.AddQuerys();
            builder.Services.AddServices();
        }

        public static void UseConfiguration(this WebApplication builder)
        {
            //Future implementation
        }
    }
}
