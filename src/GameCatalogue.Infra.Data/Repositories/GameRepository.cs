using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Interfaces;
using GameCatalogue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.Infra.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _gameContext;

        public GameRepository(ApplicationDbContext context)
        {
            _gameContext = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _gameContext.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int? id)
        {
            return await _gameContext.Games.Include(g => g.Platform).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Game> CreateAsync(Game game)
        {
            _gameContext.Add(game);
            await _gameContext.SaveChangesAsync();
            return game;
        }

        public async Task<Game> UpdateAsync(Game game)
        {
            _gameContext.Update(game);
            await _gameContext.SaveChangesAsync();
            return game;
        }

        public async Task<Game> RemoveAsync(Game game)
        {
            _gameContext.Remove(game);
            await _gameContext.SaveChangesAsync();
            return game;
        }
    }
}
