using FootballPlayersCatalog.Dal.Enums;

namespace FootballPlayersCatalog.Models.Requests.Interfaces
{
    public interface IFootballPlayerRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public int TeamId { get; init; }
        public int CountryId { get; init; }
    }
}
