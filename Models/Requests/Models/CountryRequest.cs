using FootballPlayersCatalog.Models.Requests.Interfaces;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class CountryRequest : ICountryRequest
    {
        public required string Name { get; init; }
    }
}
