using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Exceptions;

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

        public async Task<Team> GetItemByIdAsync(int id)
        {
            var team = await context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new NotFoundException($"Team with ID {id} not found");
            }
            return team;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await context.Teams.ToListAsync();
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
