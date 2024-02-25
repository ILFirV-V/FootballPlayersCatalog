using AutoMapper;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Dal.Models;

namespace FootballPlayersCatalog.Logic.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryRequest, Country>();
            CreateMap<FootballPlayerRequest, FootballPlayer>();
            CreateMap<TeamRequest, Team>();
        }
    }
}
