using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Logic.Interfaces;
using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Models.Requests.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballPlayersCatalog.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<FootballController> _logger;
        private readonly ITeamManager teamManager;

        public TeamController(ILogger<FootballController> logger, ITeamManager teamManager)
        {
            _logger = logger;
            this.teamManager = teamManager;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await teamManager.GetItemByIdAsync(id);
            return Ok(team);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await teamManager.GetAllAsync();
            if (teams is null)
            {
                return NotFound();
            }
            return Ok(teams);
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostTeam([FromBody] TeamRequest dto)
        {
            var team = await teamManager.AddAsync(dto);
            return Ok(team);
        }
    }
}