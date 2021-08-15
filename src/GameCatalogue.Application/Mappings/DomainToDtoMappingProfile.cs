using AutoMapper;
using GameCatalogue.Application.DTOs;
using GameCatalogue.Domain.Entities;

namespace GameCatalogue.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Platform, PlatformDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
