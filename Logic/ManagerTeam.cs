using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Core.Exceptions;
using FootballPlayersCatalog.Controllers.Models;

namespace FootballPlayersCatalog.Logic
{
    public class ManagerTeam
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public ManagerTeam(IMapper mapper, ApplicationContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<TeamResponse> GetItemByIdAsync(int id)
        {
            var team = await context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new NotFoundException($"Team with ID {id} not found");
            }
            var teamResponse = mapper.Map<TeamResponse>(team);
            return teamResponse;
        }

        public async Task<IEnumerable<TeamResponse>> GetAllAsync()
        {
            var teams = await context.Teams.ToListAsync();
            var teamResponses = teams.Select(mapper.Map<TeamResponse>);
            return teamResponses;
        }

        public async Task AddAsync(TeamRequest teamRequest)
        {
            if (teamRequest == null)
            {
                throw new ArgumentNullException(nameof(teamRequest), "TeamRequest cannot be null");
            }
            var team = mapper.Map<Team>(teamRequest);
            if (team == null)
            {
                throw new Exception("Failed to map teamRequest to team");
            }
            await context.Teams.AddAsync(team);
            await context.SaveChangesAsync();
        }
    }
}
