using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class TeamResponse : ITeamResponse
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
    }
}
