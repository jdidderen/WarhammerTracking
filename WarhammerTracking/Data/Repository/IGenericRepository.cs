using System.Threading.Tasks;

namespace WarhammerTracking.Data.Repository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		Task<TEntity[]> GetList();
		Task<TEntity> GetById(int id);
		Task<TEntity> GetByBattleScribeId(string id);
		Task<TEntity> GetByName(string name);
		Task Create(TEntity entity);
		Task Update(TEntity entity);
		Task Delete(int id);
	}
}