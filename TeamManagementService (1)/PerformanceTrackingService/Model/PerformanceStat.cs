using System.ComponentModel.DataAnnotations;

namespace PerformanceTrackingService.Model
{
    public class PerformanceStat
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int PointsScored { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int GamesPlayed { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
