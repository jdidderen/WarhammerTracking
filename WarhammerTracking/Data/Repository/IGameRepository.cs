using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public interface IGameRepository : IGenericRepository<Game>
	{
	}

	public interface IGameLineRepository : IGenericRepository<GameLine>
	{
	}
}