using FootballPlayersCatalog.Models.Requests.Interfaces;

namespace FootballPlayersCatalog.Models.Requests.Models
{
    public class TeamRequest : ITeamRequest
    {
        public required string Name { get; init; }
    }
}
