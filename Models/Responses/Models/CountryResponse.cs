using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class CountryResponse : ICountryResponse
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
    }
}
