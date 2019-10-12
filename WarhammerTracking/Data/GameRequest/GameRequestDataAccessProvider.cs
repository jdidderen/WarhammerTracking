using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking.Data.Game
{
    public class GameRequestDataAccessProvider
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public GameRequestDataAccessProvider(ILoggerFactory loggerFactory,ApplicationDbContext context)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logger Game Data Access");
        }
        
        public Task<GameRequest.GameRequest> GetRequestGame(int id)
        {
            return Task.FromResult(_context.GameRequests
                .Include(gr => gr.Player)
                .First(f => f.id == id));
        }

        public Task<GameRequest.GameRequest[]> ListGameRequests(ApplicationUser user)
        {
            return Task.FromResult(_context.GameRequests
                .Include(gr => gr.Player)
                .OrderByDescending(gr => gr.Date)
                .ToArray());
        }

        public Task<bool> AddGameRequest(GameRequest.GameRequest gameRequest)
        {
            try
            {
                _context.GameRequests.Add(gameRequest);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> UpdateGameRequest(GameRequest.GameRequest gameRequest)
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

        public Task<bool> DeleteGameRequest(int id)
        {
            try
            {
                GameRequest.GameRequest deleteGameRequest = _context.GameRequests.Find(id);
                _context.GameRequests.Remove(deleteGameRequest);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}