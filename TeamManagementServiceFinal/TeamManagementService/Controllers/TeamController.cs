using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamManagementService.Data;
using TeamManagementService.Model;

namespace TeamManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamContext context;
        private static readonly List<Team> teams = new List<Team>();
        private static int CurrentTeamId = 0;
        public TeamController(TeamContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> Get()
        {
            return await context.Teams.ToListAsync();
        }

        // create team
        [HttpPost("createTeam")]
        public IActionResult CreateTeam([FromBody] Team team)
        {
            // check to make sure user required to enter team name
            if (string.IsNullOrEmpty(team.TeamName))
            {
                return BadRequest("Team name is required");
            }
            // check if team name already taking
            if (teams.Any(x => x.TeamName == team.TeamName))
            {
                return BadRequest("Team already exist");
            }
            team.TeamId = CurrentTeamId;
            CurrentTeamId++;
            teams.Add(team);
            return Ok("Sucessfully create a team");
        }

        // update team
        [HttpPost("UpdateTeam")]
        public IActionResult UpdateTeam([FromBody] Team updateTeam)
        {
            // check if team id match
            var team = teams.Find(x => x.TeamId == updateTeam.TeamId);
            if (team == null) // team id does not match
            {
                return Ok("Cannot find the team id");
            }
            else // team id match
            {
                team.TeamName = updateTeam.TeamName;
                return Ok("Team has been updated");
            }
        }

        // retrive team based on team id
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            var team = await context.Teams.FindAsync(id);
            //validation to see if the team exist
            if (team == null)
            {
                return NotFound();
            }
            return team;
        }
    }
}
