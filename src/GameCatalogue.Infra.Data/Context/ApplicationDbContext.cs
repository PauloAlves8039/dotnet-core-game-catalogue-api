using GameCatalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
