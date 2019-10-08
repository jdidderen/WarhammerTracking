using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking.Data.Army
{
    public class FactionDataAccessProvider
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public FactionDataAccessProvider(ILoggerFactory loggerFactory,ApplicationDbContext context)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logger Faction Data Access");
        }
        
        public Task<Faction> GetFaction(int id)
        {
            return Task.FromResult(_context.Factions.Include(f => f.army).First(f => f.id == id));
        }

        public Task<Faction[]> ListFaction()
        {
            return Task.FromResult(_context.Factions.Include(f => f.army).ToArray());
        }

        public Task<bool> AddFaction(Faction faction)
        {
            try
            {
                _context.Factions.Add(faction);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> UpdateFaction(Faction faction)
        {
            try
            {
                _context.Entry(faction).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteFaction(int id)
        {
            try
            {
                Faction deleteFaction = _context.Factions.Find(id);
                _context.Factions.Remove(deleteFaction);
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