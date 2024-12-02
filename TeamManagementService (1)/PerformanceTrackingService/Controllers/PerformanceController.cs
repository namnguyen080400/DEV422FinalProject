using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceTrackingService.Data;
using PerformanceTrackingService.Model;

namespace PerformanceTrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerformanceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdatePerformance([FromBody] PerformanceStat performanceStat)
        {
            var existingStat = await _context.PerformanceStats
                .FirstOrDefaultAsync(x => x.PlayerId == performanceStat.PlayerId);

            if (existingStat != null)
            {
                existingStat.PointsScored += performanceStat.PointsScored;
                existingStat.Assists += performanceStat.Assists;
                existingStat.Rebounds += performanceStat.Rebounds;
                existingStat.GamesPlayed += 1;
                existingStat.LastUpdated = DateTime.UtcNow;
            }
            else
            {
                _context.PerformanceStats.Add(performanceStat);
            }

            await _context.SaveChangesAsync();
            return Ok("Performance stats updated successfully.");
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<PerformanceStat>> GetPerformance(int playerId)
        {
            var performanceStat = await _context.PerformanceStats.FirstOrDefaultAsync(x => x.PlayerId == playerId);
            if (performanceStat == null)
            {
                return NotFound();
            }
            return performanceStat;
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<PerformanceStat>>> GetTeamPerformance(int teamId)
        {
            return await _context.PerformanceStats.Where(x => x.TeamId == teamId).ToListAsync();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PerformanceStat>>> GetAllPerformanceStats()
        {
            return await _context.PerformanceStats.ToListAsync();
        }
    }
}
