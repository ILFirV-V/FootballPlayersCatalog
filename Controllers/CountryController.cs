using Microsoft.AspNetCore.Mvc;
using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Logic.Interfaces;

namespace FootballPlayersCatalog.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryManager countryManager;

        public CountryController(ILogger<CountryController> logger, ICountryManager countryManager)
        {
            _logger = logger;
            this.countryManager = countryManager;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var footballer = await countryManager.GetItemByIdAsync(id);
            return Ok(footballer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var footballPlayers = await countryManager.GetAllAsync();
            return Ok(footballPlayers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostUser(ICountryRequest dto)
        {
            var country = await countryManager.AddAsync(dto);
            return StatusCode(StatusCodes.Status201Created, country);
        }
    }
}
