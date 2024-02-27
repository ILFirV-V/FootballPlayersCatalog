﻿using AutoMapper;
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

            CreateMap<FootballPlayer, FootballPlayerResponse>()
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<Team, TeamResponse>();
            CreateMap<Country, CountryResponse>();
        }
    }
}
