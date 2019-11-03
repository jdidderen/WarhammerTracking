using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public interface IUnitRepository : IGenericRepository<Unit>
	{
	}

	public interface ICategoryRepository : IGenericRepository<Category>
	{
	}

	public interface IUnitCategoryRepository : IGenericRepository<UnitCategory>
	{
		Task<UnitCategory> GetbyIds(int categoryId, int unitId);
		Task<UnitCategory> GetbyBattleScribeIds(string categoryId, string unitId);
	}

	public interface IKeywordRepository : IGenericRepository<Keyword>
	{
	}

	public interface IUnitKeywordRepository : IGenericRepository<UnitKeyword>
	{
		Task<UnitKeyword> GetbyIds(int keywordId, int unitId);
		Task<UnitKeyword> GetbyBattleScribeIds(string keywordId, string unitId);
	}
}