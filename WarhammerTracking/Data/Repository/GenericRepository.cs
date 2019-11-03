using System.Linq;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity>
		where TEntity : class, IEntity
	{
		internal readonly ApplicationDbContext DbContext;

		protected GenericRepository(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task<TEntity[]> GetList()
		{
			return await Task.FromResult(DbContext.Set<TEntity>().ToArray());
		}

		public async Task<TEntity> GetById(int id)
		{
			return await Task.FromResult(DbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id));
		}

		public async Task<TEntity> GetByBattleScribeId(string id)
		{
			return await Task.FromResult(DbContext.Set<TEntity>().FirstOrDefault(e => e.BattleScribeId == id));
		}

		public async Task<TEntity> GetByName(string name)
		{
			return await Task.FromResult(DbContext.Set<TEntity>().FirstOrDefault(e => e.Name == name));
		}

		public async Task Create(TEntity entity)
		{
			DbContext.Set<TEntity>().Add(entity);
			await DbContext.SaveChangesAsync();
		}

		public async Task Update(TEntity entity)
		{
			DbContext.Set<TEntity>().Update(entity);
			await DbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
			DbContext.Set<TEntity>().Remove(entity);
			await DbContext.SaveChangesAsync();
		}
	}
}