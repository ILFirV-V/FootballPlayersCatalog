using AutoMapper;
using FootballPlayersCatalog.Controllers.Models;
using FootballPlayersCatalog.Dal.Models;
using FootballPlayersCatalog.Models.Requests.Interfaces;
using FootballPlayersCatalog.Models.Responses.Interfaces;

namespace FootballPlayersCatalog.Logic.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ICountryRequest, Country>();
            CreateMap<IFootballPlayerRequest, FootballPlayer>();
            CreateMap<ITeamRequest, Team>();

            CreateMap<Team, TeamResponse>();
            CreateMap<Country, CountryResponse>();
            CreateMap<FootballPlayer, FootballPlayerResponse>()
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => new TeamResponse { Id = src.Team.Id, Name = src.Team.Name }))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => new CountryResponse { Id = src.Country.Id, Name = src.Country.Name }));
        }
    }
}
