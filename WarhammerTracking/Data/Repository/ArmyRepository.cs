using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class ArmyRepository : GenericRepository<Army>, IArmyRepository
	{
		public ArmyRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}