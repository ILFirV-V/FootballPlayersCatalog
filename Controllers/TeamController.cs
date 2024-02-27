using FootballPlayersCatalog.Logic.Interfaces;
using FootballPlayersCatalog.Models.Requests.Interfaces;
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
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await teamManager.GetItemByIdAsync(id);
            if (team is null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var footballPlayers = await teamManager.GetAllAsync();
            if (footballPlayers is null)
            {
                return NotFound();
            }
            return Ok(footballPlayers);
        }


        [HttpPost]
        public async Task<IActionResult> PostTeam([FromBody] ITeamRequest dto)
        {
            await teamManager.AddAsync(dto);
            return Ok();
        }
    }
}