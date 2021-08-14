using GameCatalogue.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Domain.Interfaces
{
    public interface IPlatformRepository
    {
        Task<IEnumerable<Platform>> GetPlatforms();

        Task<Platform> GetById(int? id);

        Task<Platform> Create(Platform platform);

        Task<Platform> Update(Platform platform);

        Task<Platform> Remove(Platform platform);
    }
}
