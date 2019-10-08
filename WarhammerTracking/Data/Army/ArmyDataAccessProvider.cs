using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking.Data.Army
{
    public class ArmyDataAccessProvider
    {
        private readonly ILogger Logger;
        private readonly ApplicationDbContext _context;
        
        public ArmyDataAccessProvider(ILoggerFactory loggerFactory,ApplicationDbContext context)
        {
            _context = context;
            Logger = loggerFactory.CreateLogger("Logger Army Data Access");
        }

        public Task<Army> GetArmy(int id)
        {
            return Task.FromResult(_context.Armies.First(a => a.id == id));
        }

        public Task<Army[]> ListArmy()
        {
            return Task.FromResult(_context.Armies.ToArray());
        }

        public Task<bool> AddArmy(Army army)
        {
            try
            {
                _context.Armies.Add(army);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);        }

        public Task<bool> UpdateArmy(Army army)
        {
            try
            {
                _context.Entry(army).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteArmy(int id)
        {
            try
            {
                Army deleteArmy = _context.Armies.Find(id);
                _context.Armies.Remove(deleteArmy);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}