using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class GameTableRepository : GenericRepository<GameTable>, IGameTableRepository
	{
		public GameTableRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}