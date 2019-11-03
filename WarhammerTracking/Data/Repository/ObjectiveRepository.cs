using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class ObjectiveRepository : GenericRepository<Objective>, IObjectiveRepository
	{
		public ObjectiveRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}