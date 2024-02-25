using FootballPlayersCatalog.Dal.Enums;
using FootballPlayersCatalog.Core.Dal.Interfaces;

namespace FootballPlayersCatalog.Dal.Models
{
    public record class FootballPlayer : IDalModel<int>
    {
        public int Id { get; init; }
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
        public Gender Gender { get; init; }
        public DateOnly Birthday { get; init; }
        public int TeamId { get; init; }
        public Team Team { get; init; }
        public int CountryId { get; init; }
        public Country Country { get; init; }
    }
}
