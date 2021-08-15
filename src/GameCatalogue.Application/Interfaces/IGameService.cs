using GameCatalogue.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetGames();

        Task<GameDto> GetById(int? id);

        Task Add(GameDto gameDto);

        Task Update(GameDto gameDto);

        Task Remove(int? id);
    }
}
