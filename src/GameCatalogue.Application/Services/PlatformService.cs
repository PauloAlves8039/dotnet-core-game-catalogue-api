using AutoMapper;
using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Interfaces;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Services
{
    public class PlatformService : IPlatformService
    {
        private IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformService(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformDto>> GetPlatforms()
        {
            var platformsEntity = await _platformRepository.GetPlatforms();
            return _mapper.Map<IEnumerable<PlatformDto>>(platformsEntity);
        }

        public async Task<PlatformDto> GetById(int? id)
        {
            var platformEntity = await _platformRepository.GetById(id);
            return _mapper.Map<PlatformDto>(platformEntity);
        }

        public async Task Add(PlatformDto platformDto)
        {
            var platformEntity = _mapper.Map<Platform>(platformDto);
            await _platformRepository.Create(platformEntity);
        }

        public async Task Update(PlatformDto platformDto)
        {
            var platformEntity = _mapper.Map<Platform>(platformDto);
            await _platformRepository.Update(platformEntity);
        }

        public async Task Remove(int? id)
        {
            var platformEntity = _platformRepository.GetById(id).Result;
            await _platformRepository.Remove(platformEntity);
        }
    }
}
