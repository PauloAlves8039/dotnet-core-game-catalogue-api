using GameCatalogue.Application.Games.Queries;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Games.Handlers
{
    public class GetGamesQueryHandle : IRequestHandler<GetGamesQuery, IEnumerable<Game>>
    {
        private readonly IGameRepository _gameRepository;

        public GetGamesQueryHandle(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public async Task<IEnumerable<Game>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            return await _gameRepository.GetGamesAsync();
        }
    }
}
