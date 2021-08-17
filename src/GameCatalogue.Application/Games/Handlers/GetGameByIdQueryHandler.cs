using GameCatalogue.Application.Games.Queries;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Games.Handlers
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameByIdQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            return await _gameRepository.GetByIdAsync(request.Id);
        }
    }
}
