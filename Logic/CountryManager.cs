using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Core.Exceptions;
using FootballPlayersCatalog.Models.Requests.Models;
using FootballPlayersCatalog.Logic.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;
using FootballPlayersCatalog.Models.Requests.Interfaces;

namespace FootballPlayersCatalog.Logic
{
    public class CountryManager : ICountryManager
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public CountryManager(IMapper mapper, ApplicationContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICountryResponse> GetItemByIdAsync(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country == null)
            {
                throw new NotFoundException($"Country with ID {id} not found");
            }
            var сountryResponse = mapper.Map<CountryResponse>(country);
            return сountryResponse;
        }

        public async Task<IEnumerable<ICountryResponse>> GetAllAsync()
        {
            var countries = await context.Countries.ToListAsync();
            var countryResponses = countries.Select(mapper.Map<CountryResponse>);
            return countryResponses;
        }

        public async Task<ICountryResponse> AddAsync(ICountryRequest countryRequest)
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
            var сountryResponse = mapper.Map<ICountryResponse>(сountry);
            return сountryResponse;
        }
    }
}
