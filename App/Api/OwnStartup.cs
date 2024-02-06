using Shared.Registration;

namespace Api
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSharedRegistration();
        }

        public static void UseConfiguration(this WebApplication _)
        {
            //Future implementation
        }
    }
}
