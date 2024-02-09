using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext() : base() { }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema("auth");
            base.OnModelCreating(builder);

            builder.Entity<UserAuthorization>();
        }
    }
}
