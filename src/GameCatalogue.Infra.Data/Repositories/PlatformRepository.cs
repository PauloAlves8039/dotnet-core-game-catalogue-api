using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using GameCatalogue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Infra.Data.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private ApplicationDbContext _platformContext;

        public PlatformRepository(ApplicationDbContext context)
        {
            _platformContext = context;
        }

        public async Task<IEnumerable<Platform>> GetPlatforms()
        {
            return await _platformContext.Platforms.ToListAsync();
        }

        public async Task<Platform> GetById(int? id)
        {
            return await _platformContext.Platforms.FindAsync(id);
        }

        public async Task<Platform> Create(Platform platform)
        {
            _platformContext.Add(platform);
            await _platformContext.SaveChangesAsync();
            return platform;
        }

        public async Task<Platform> Update(Platform platform)
        {
            _platformContext.Update(platform);
            await _platformContext.SaveChangesAsync();
            return platform;
        }

        public async Task<Platform> Remove(Platform platform)
        {
            _platformContext.Remove(platform);
            await _platformContext.SaveChangesAsync();
            return platform;
        }
    }
}
