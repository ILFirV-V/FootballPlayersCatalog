using FootballPlayersCatalog.Dal.Enums;

namespace FootballPlayersCatalog.Models.Responses.Interfaces
{
    public interface IFootballPlayerResponse
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public ITeamResponse Team { get; init; }
        public ICountryResponse Country { get; init; }
    }
}
