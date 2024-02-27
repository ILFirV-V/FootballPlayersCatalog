using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Logic.Interfaces
{
    public interface ICountryManager
    {
        Task<ICountryResponse> GetItemByIdAsync(int id);
        Task<IEnumerable<ICountryResponse>> GetAllAsync();
        Task<ICountryResponse> AddAsync(ICountryRequest countryRequest);
    }
}
