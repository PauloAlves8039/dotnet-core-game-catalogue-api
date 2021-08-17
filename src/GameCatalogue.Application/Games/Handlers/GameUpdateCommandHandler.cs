using GameCatalogue.Application.Games.Commands;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Games.Handlers
{
    public class GameUpdateCommandHandler : IRequestHandler<GameUpdateCommand, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GameUpdateCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentException(nameof(gameRepository));
        }
        
        public async Task<Game> Handle(GameUpdateCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);

            if (game == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else 
            {
                game.Update(request.Name, request.Producer, request.Gender, request.Quantity, request.Image, request.PlatformId);
                return await _gameRepository.UpdateAsync(game);
            }
        }
    }
}
