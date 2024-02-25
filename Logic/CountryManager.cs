using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Exceptions;

namespace FootballPlayersCatalog.Logic
{
    public class CountryManager
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public CountryManager(IMapper mapper, ApplicationContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Country> GetItemByIdAsync(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country == null)
            {
                throw new NotFoundException($"Country with ID {id} not found");
            }
            return country;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await context.Countries.ToListAsync();
        }

        public async Task<Country> AddAsync(CountryRequest countryRequest)
        {
            if (countryRequest == null)
            {
                throw new ArgumentNullException(nameof(countryRequest), "Football player request cannot be null");
            }
            var сountry = mapper.Map<Country>(countryRequest);
            if (сountry == null)
            {
                throw new Exception("Failed to map CountryRequest to Country");
            }
            await context.Countries.AddAsync(сountry);
            await context.SaveChangesAsync();
            return сountry;
        }
    }
}
