using Microsoft.EntityFrameworkCore;

namespace BaseAPI.DomainDrivenDesign.Infrastructure.Context
{
	public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbAppContext).Assembly);
        }
    }
}

