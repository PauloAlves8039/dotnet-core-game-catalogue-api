using GameCatalogue.Application.Games.Commands;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Games.Handlers
{
    public class GameRemoveCommandHandler : IRequestHandler<GameRemoveCommand, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GameRemoveCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }
        
        public async Task<Game> Handle(GameRemoveCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);

            if (game == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else 
            {
                var result = await _gameRepository.RemoveAsync(game);
                return result;
            }
        }
    }
}
