using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class GameRequestRepository : GenericRepository<GameRequest>, IGameRequestRepository
	{
		public GameRequestRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}