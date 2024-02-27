using FootballPlayersCatalog.Core.Dal.Interfaces;

namespace FootballPlayersCatalog.Dal.Models
{
    public record class Team : IDalModel<int>
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public IList<FootballPlayer> FootballPlayers { get; init; }
    }
}
