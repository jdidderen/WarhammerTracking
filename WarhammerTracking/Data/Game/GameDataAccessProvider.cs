using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking.Data.Game
{
    public class GameDataAccessProvider
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public GameDataAccessProvider(ILoggerFactory loggerFactory,ApplicationDbContext context)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logger Game Data Access");
        }
        
        public Task<Game> GetGame(int id)
        {
            return Task.FromResult(_context.Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.GameLines)
                .ThenInclude(l => l.Player)
                .First(f => f.id == id));
        }

        public Task<Game[]> ListGame()
        {
            return Task.FromResult(_context.Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.GameLines)
                .ThenInclude(l => l.Player)
                .OrderByDescending(g => g.Date)
                .ToArray());
        }

        public Task<bool> AddGame(Game game)
        {
            try
            {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> UpdateGame(Game game)
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteGame(int id)
        {
            try
            {
                Game deleteGame = _context.Games.Find(id);
                _context.Games.Remove(deleteGame);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<Game[]> LastFiveGames()
        {
            return Task.FromResult(_context.Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.GameLines)
                .ThenInclude(l => l.Player)
                .OrderByDescending(g => g.Date)
                .Where(g => g.Date < DateTime.Now)
                .Take(5)
                .ToArray());
        }
        
        public Task<Game[]> NextFiveGames()
        {
            return Task.FromResult(_context.Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.GameLines)
                .ThenInclude(l => l.Player)
                .OrderByDescending(g => g.Date)
                .Where(g => g.Date > DateTime.Now)
                .Take(5)
                .ToArray());
        }
    }
}