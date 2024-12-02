using Microsoft.EntityFrameworkCore;
using PerformanceTrackingService.Model;

namespace PerformanceTrackingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PerformanceStat> PerformanceStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerformanceStat>().HasData(
                new PerformanceStat
                {
                    Id = 1,
                    PlayerId = 101,
                    PointsScored = 30,
                    Assists = 10,
                    Rebounds = 12,
                    GamesPlayed = 5,
                    LastUpdated = DateTime.UtcNow
                },
                new PerformanceStat
                {
                    Id = 2,
                    PlayerId = 102,
                    PointsScored = 22,
                    Assists = 8,
                    Rebounds = 7,
                    GamesPlayed = 5,
                    LastUpdated = DateTime.UtcNow
                }
            );
        }
    }
}
