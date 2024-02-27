using FootballPlayersCatalog.Dal.Enums;
using FootballPlayersCatalog.Models.Requests.Interfaces;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class FootballPlayerRequest : IFootballPlayerRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public int TeamId { get; init; }
        public int CountryId { get; init; }
    }
}
