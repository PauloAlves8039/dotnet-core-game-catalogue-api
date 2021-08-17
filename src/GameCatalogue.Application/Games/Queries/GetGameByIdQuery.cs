using GameCatalogue.Domain.Entities;
using MediatR;

namespace GameCatalogue.Application.Games.Queries
{
    public class GetGameByIdQuery : IRequest<Game>
    {
        public int Id { get; set; }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }
}
