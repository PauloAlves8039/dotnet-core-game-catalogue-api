using GameCatalogue.Domain.Entities;
using MediatR;

namespace GameCatalogue.Application.Games.Commands
{
    public abstract class GameCommand : IRequest<Game>
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Gender { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int PlatformId { get; set; }
    }
}
