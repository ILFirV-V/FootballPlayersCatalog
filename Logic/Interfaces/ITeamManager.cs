using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Logic.Interfaces
{
    public interface ITeamManager
    {
        Task<ITeamResponse> GetItemByIdAsync(int id);
        Task<IEnumerable<ITeamResponse>> GetAllAsync();
        Task AddAsync(ITeamRequest teamRequest);
    }
}
