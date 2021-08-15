using AutoMapper;
using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Interfaces;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository ?? throw new ArgumentException(nameof(gameRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDto>> GetGames()
        {
            var gamesEntity = await _gameRepository.GetGamesAsync();
            return _mapper.Map<IEnumerable<GameDto>>(gamesEntity);
        }

        public async Task<GameDto> GetById(int? id)
        {
            var gameEntity = await _gameRepository.GetByIdAsync(id);
            return _mapper.Map<GameDto>(gameEntity);
        }

        public async Task Add(GameDto gameDto)
        {
            var gameEntity = _mapper.Map<Game>(gameDto);
            await _gameRepository.CreateAsync(gameEntity);
        }

        public async Task Update(GameDto gameDto)
        {
            var gameEntity = _mapper.Map<Game>(gameDto);
            await _gameRepository.UpdateAsync(gameEntity);
        }

        public async Task Remove(int? id)
        {
            var gameEntity = _gameRepository.GetByIdAsync(id).Result;
            await _gameRepository.RemoveAsync(gameEntity);
        } 
    }
}
