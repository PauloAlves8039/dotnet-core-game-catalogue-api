using GameCatalogue.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();

        Task<Game> GetByIdAsync(int? id);

        Task<Game> CreateAsync(Game game);

        Task<Game> UpdateAsync(Game game);

        Task<Game> RemoveAsync(Game game);
    }
}
