using Microsoft.AspNetCore.Mvc;
using FootballPlayersCatalog.Logic;
using FootballPlayersCatalog.Controllers.Models;

namespace FootballPlayersCatalog.Controllers
{
    [ApiController]
    [Route("players")]
    public class FootballController : ControllerBase
    {
        private readonly ILogger<FootballController> _logger;
        private readonly ManagerFootballPlayer managerFootballPlayer;

        public FootballController(ILogger<FootballController> logger, ManagerFootballPlayer footballerManager)
        {
            _logger = logger;
            managerFootballPlayer = footballerManager;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var footballer = await managerFootballPlayer.GetItemByIdAsync(id);
            return Ok(footballer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var footballPlayers = await managerFootballPlayer.GetAllAsync();
            return Ok(footballPlayers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostUser([FromBody] FootballPlayerRequest dto)
        {
            var footballPlayer = await managerFootballPlayer.AddAsync(dto);
            return StatusCode(StatusCodes.Status201Created, footballPlayer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await managerFootballPlayer.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] FootballPlayerRequest dto)
        {
            var footballPlayer = await managerFootballPlayer.UpdateUser(id, dto);
            return Ok(footballPlayer);
        }
    }
}