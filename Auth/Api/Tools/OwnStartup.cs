using Database;
using Domain.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Querys;
using Services;
using Shared.Infra;
using Shared.Registration;

namespace Api.Tools
{
    public static class OwnStartup
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSharedRegistration();
            builder.Services.AddInternalQuerys();
            builder.Services.AddInternalServices();

            var connection = builder.Configuration.Get<DbConnection>();

            if (connection!.UseCached)
            {
                builder.Services.AddDbContext<AuthDbContext>(op => op.UseInMemoryDatabase(connection!.ConnectionDatabase.DatabaseName!));
            }
            else
            {
                builder.Services.AddDbContext<AuthDbContext>(op => op.UseNpgsql(connection!.ConnectionDatabase.ConnectionStrings!, p => p.EnableRetryOnFailure(5)));
            }

            builder.AddLocalAutentication<AuthDbContext>();
            builder.AddAuthentication();
        }

        public static void UseConfiguration(this WebApplication builder)
        {
            builder.MapGroup("/auth").MapIdentityApi<User>();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration.Get<AuthenticationSettings>();

            foreach (var authConfig in config!.Authentications)
            {
                switch (authConfig.Method)
                {
                    case Shared.Infra.Enums.AuthenticationMethod.None:
                        break;

                    case Shared.Infra.Enums.AuthenticationMethod.Password:
                        builder.Services.AddAuthentication(options => {
                            options.DefaultScheme = "Identity.Application";
                            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        })
                        .AddCookie("Identity.Application", options =>
                        {
                            options.Cookie.Name = "folks.auth";
                            options.LoginPath = new PathString("/auth/login");
                            options.LogoutPath = new PathString("/auth/logout");
                            options.AccessDeniedPath = new PathString("/auth/denied");
                            options.Cookie.HttpOnly = true;
                            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                        });
                        break;

                    case Shared.Infra.Enums.AuthenticationMethod.Google:
                        builder.Services.AddAuthentication(options =>
                        {
                            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                        })
                        .AddCookie()
                        .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                        {
                            options.ClientId = authConfig.Id!;
                            options.ClientSecret = authConfig.Key!;
                        });
                        break;

                    case Shared.Infra.Enums.AuthenticationMethod.Instagram:
                    case Shared.Infra.Enums.AuthenticationMethod.X:
                    default:
                        throw new NotImplementedException($"Method {authConfig.Method} not implemented");
                }
            }

            builder.Services.AddAuthorizationBuilder();
        }

        private static void AddLocalAutentication<Db>(this WebApplicationBuilder builder)
            where Db : DbContext
        {
            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<Db>()
                .AddApiEndpoints();
        }
    }
}
