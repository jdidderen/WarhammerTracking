using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class ScenarioRepository : GenericRepository<Scenario>, IScenarioRepository
	{
		public ScenarioRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}