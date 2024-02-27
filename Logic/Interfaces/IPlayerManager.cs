using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Logic.Interfaces
{
    public interface IPlayerManager
    {
        Task<IFootballPlayerResponse> GetItemByIdAsync(int id);
        Task<IEnumerable<IFootballPlayerResponse>> GetAllAsync();
        Task<IFootballPlayerResponse> AddAsync(IFootballPlayerRequest player);
        Task<IFootballPlayerResponse> UpdateUser(int id, IFootballPlayerRequest player);
        Task DeleteAsync(int id);
    }
}
