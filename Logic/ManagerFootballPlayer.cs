using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Core.Exceptions;

namespace FootballPlayersCatalog.Logic
{
    public class ManagerFootballPlayer
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public ManagerFootballPlayer(IMapper mapper, ApplicationContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<FootballPlayerResponse> GetItemByIdAsync(int id)
        {
            var player = await context.FootballPlayers
                .Include(u => u.Team)
                .Include(u => u.Country)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (player == null)
            {
                throw new NotFoundException($"Football player with ID {id} not found");
            }
            var playerResponse = mapper.Map<FootballPlayerResponse>(player);
            return playerResponse;
        }

        public async Task<IEnumerable<FootballPlayerResponse>> GetAllAsync()
        {
            var players = await context.FootballPlayers
                .Include(u => u.Team)
                .Include(u => u.Country)
                .ToListAsync();
            var playerResponse = players.Select(mapper.Map<FootballPlayerResponse>);
            return playerResponse;
        }

        public async Task<FootballPlayerResponse> AddAsync(FootballPlayerRequest player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Football player request cannot be null");
            }
            var footballPlayer = mapper.Map<FootballPlayer>(player);
            if (footballPlayer == null)
            {
                throw new Exception("Failed to map FootballPlayerRequest to FootballPlayer");
            }
            var footballPlayerResponse = await context.FootballPlayers.AddAsync(footballPlayer);
            await context.SaveChangesAsync();
            var playerResponse = mapper.Map<FootballPlayerResponse>(footballPlayerResponse);
            return playerResponse;
        }

        public async Task<FootballPlayerResponse> UpdateUser(int id, FootballPlayerRequest player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Football player request cannot be null");
            }
            var footballPlayer = mapper.Map<FootballPlayer>(player);
            if (footballPlayer == null)
            {
                throw new Exception("Failed to map FootballPlayerRequest to FootballPlayer");
            }
            footballPlayer = footballPlayer with { Id = id };
            var footballPlayerResponse = context.FootballPlayers.Update(footballPlayer);
            await context.SaveChangesAsync();
            var playerResponse = mapper.Map<FootballPlayerResponse>(footballPlayerResponse);
            return playerResponse;
        }

        public async Task DeleteAsync(int id)
        {
            var footballPlayer = await context.FootballPlayers.FindAsync(id);
            if (footballPlayer == null)
            {
                throw new NotFoundException($"Football player with ID {id} not found");
            }
            context.FootballPlayers.Remove(footballPlayer);
            await context.SaveChangesAsync();
        }
    }
}
