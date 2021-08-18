using AutoMapper;
using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Games.Commands;

namespace GameCatalogue.Application.Mappings
{
    public class DtoCommandMappingProfile : Profile
    {
        public DtoCommandMappingProfile()
        {
            CreateMap<GameDto, GameCreateCommand>();
            CreateMap<GameDto, GameUpdateCommand>();
        }
    }
}
