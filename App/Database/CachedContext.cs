using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class CachedContext : DbContext
    {
        protected CachedContext() : base() { }

        public CachedContext(DbContextOptions<CachedContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("app");
            base.OnModelCreating(builder);

            builder.Entity<StreamKey>();
            builder.Entity<VideoStructure>();
        }
    }
}
