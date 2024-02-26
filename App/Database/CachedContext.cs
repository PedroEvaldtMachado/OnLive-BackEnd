using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class CachedContext : DbContext
    {
        protected CachedContext() : base() { }

        public CachedContext(DbContextOptions<CachedContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StreamKey>();
            modelBuilder.Entity<VideoStructure>();
        }
    }
}
