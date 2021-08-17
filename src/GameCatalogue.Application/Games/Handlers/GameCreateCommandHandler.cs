using GameCatalogue.Application.Games.Commands;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Games.Handlers
{
    public class GameCreateCommandHandler : IRequestHandler<GameCreateCommand, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GameCreateCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public async Task<Game> Handle(GameCreateCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.Name, request.Producer, request.Gender, request.Quantity, request.Image);

            if (game == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else 
            {
                game.PlatformId = request.PlatformId;
                return await _gameRepository.CreateAsync(game);
            }
        }
    }
}
