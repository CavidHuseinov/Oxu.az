
using Microsoft.EntityFrameworkCore;
using Oxu.Domain.Entities;
using System.Reflection;

namespace Oxu.Presentation.Context
{
    public sealed class OxuDbContext : DbContext
    {
        public OxuDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HeadBanner> HeadBanners { get; set; }
        public DbSet<HeadBannerTranslation> HeadBannerTranslations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
