using FootballPlayersCatalog.Dal.Enums;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class FootballPlayerRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public int TeamId { get; init; }
        public int CountryId { get; init; }
    }
}
