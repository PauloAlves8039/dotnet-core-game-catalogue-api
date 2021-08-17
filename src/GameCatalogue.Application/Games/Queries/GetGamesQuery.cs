using GameCatalogue.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GameCatalogue.Application.Games.Queries
{
    public class GetGamesQuery : IRequest<IEnumerable<Game>>
    {
    }
}
