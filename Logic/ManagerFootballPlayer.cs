using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Exceptions;

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

        public async Task<FootballPlayer> GetItemByIdAsync(int id)
        {
            var player = await context.FootballPlayers.FindAsync(id);
            if (player == null)
            {
                throw new NotFoundException($"Football player with ID {id} not found");
            }
            return player;
        }

        public async Task<IEnumerable<FootballPlayer>> GetAllAsync()
        {
            return await context.FootballPlayers.ToListAsync();
        }

        public async Task<FootballPlayer> AddAsync(FootballPlayerRequest player)
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
            await context.FootballPlayers.AddAsync(footballPlayer);
            await context.SaveChangesAsync();
            return footballPlayer;
        }

        public async Task<FootballPlayer> UpdateUser(int id, FootballPlayerRequest player)
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
            context.FootballPlayers.Update(footballPlayer);
            await context.SaveChangesAsync();
            return footballPlayer;
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
