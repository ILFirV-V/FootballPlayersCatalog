using FootballPlayersCatalog.Dal.Enums;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class FootballPlayerResponse
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public required TeamResponse Team { get; init; }
        public required CountryResponse Country { get; init; }
    }
}
