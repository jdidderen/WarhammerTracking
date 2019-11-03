using System.Linq;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class GameRepository : GenericRepository<Game>, IGameRepository
	{
		public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public new async Task<Game[]> GetList()
		{
			return await Task.FromResult(DbContext.Set<Game>().ToArray());
		}
	}

	public class GameLineRepository : GenericRepository<GameLine>, IGameLineRepository
	{
		public GameLineRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}