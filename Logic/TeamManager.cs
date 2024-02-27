using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Core.Exceptions;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Logic.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;
using FootballPlayersCatalog.Models.Requests.Interfaces;

namespace FootballPlayersCatalog.Logic
{
    public class TeamManager : ITeamManager
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public TeamManager(IMapper mapper, ApplicationContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ITeamResponse> GetItemByIdAsync(int id)
        {
            var team = await context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new NotFoundException($"Team with ID {id} not found");
            }
            var teamResponse = mapper.Map<TeamResponse>(team);
            return teamResponse;
        }

        public async Task<IEnumerable<ITeamResponse>> GetAllAsync()
        {
            var teams = await context.Teams.ToListAsync();
            if (teams is null)
            {
                throw new NotFoundException($"Teams not found");
            }
            var teamResponses = teams.Select(mapper.Map<TeamResponse>);
            return teamResponses;
        }

        public async Task<ITeamResponse> AddAsync(ITeamRequest teamRequest)
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
            var addTeam = await context.Teams.AddAsync(team);
            if (addTeam is null)
            {
                throw new NotFoundException($"add team not found");
            }
            await context.SaveChangesAsync();
            var teamResponse = mapper.Map<TeamResponse>(addTeam.Entity);
            return teamResponse;
        }
    }
}
