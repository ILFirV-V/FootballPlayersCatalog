using FootballPlayersCatalog.Dal.Enums;
using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class FootballPlayerResponse : IFootballPlayerResponse
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public required ITeamResponse Team { get; init; }
        public required ICountryResponse Country { get; init; }
    }
}
