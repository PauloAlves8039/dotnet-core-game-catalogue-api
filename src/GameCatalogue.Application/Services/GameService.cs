using AutoMapper;
using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Games.Commands;
using GameCatalogue.Application.Games.Queries;
using GameCatalogue.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GameService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GameDto>> GetGames()
        {
            var gamesQuery = new GetGamesQuery();

            if (gamesQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            var result = await _mediator.Send(gamesQuery);

            return _mapper.Map<IEnumerable<GameDto>>(result);
        }

        public async Task<GameDto> GetById(int? id)
        {
            var gameByIdQuery = new GetGameByIdQuery(id.Value);

            if (gameByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(gameByIdQuery);

            return _mapper.Map<GameDto>(result);
        }

        public async Task Add(GameDto gameDto)
        {
            var gameCreateCommand = _mapper.Map<GameCreateCommand>(gameDto);
            await _mediator.Send(gameCreateCommand);
        }

        public async Task Update(GameDto gameDto)
        {
            var gameUpdateCommand = _mapper.Map<GameUpdateCommand>(gameDto);
            await _mediator.Send(gameUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var gameRemoveCommand = new GameRemoveCommand(id.Value);

            if (gameRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(gameRemoveCommand);
        } 
    }
}
