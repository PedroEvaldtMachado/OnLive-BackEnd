using Shared.Registration;

namespace Api
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSharedRegistration(builder.Configuration.GetSection);
        }

        public static void UseConfiguration(this WebApplication builder)
        {
            //Future implementation
        }
    }
}
