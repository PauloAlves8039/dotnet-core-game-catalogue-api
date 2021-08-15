using GameCatalogue.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Application.Interfaces
{
    public interface IPlatformService
    {
        Task<IEnumerable<PlatformDto>> GetPlatforms();

        Task<PlatformDto> GetById(int? id);

        Task Add(PlatformDto platformDto);

        Task Update(PlatformDto platformDto);

        Task Remove(int? id);
    }
}
