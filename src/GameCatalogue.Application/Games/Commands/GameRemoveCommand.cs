using GameCatalogue.Domain.Entities;
using MediatR;

namespace GameCatalogue.Application.Games.Commands
{
    public class GameRemoveCommand : IRequest<Game>
    {
        public int Id { get; set; }

        public GameRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
