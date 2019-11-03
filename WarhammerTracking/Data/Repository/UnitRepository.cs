using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data.Repository
{
	public class UnitRepository : GenericRepository<Unit>, IUnitRepository
	{
		public UnitRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}

	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}

	public class UnitCategoryRepository : GenericRepository<UnitCategory>, IUnitCategoryRepository
	{
		public UnitCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public Task<UnitCategory> GetbyIds(int categoryId, int unitId)
		{
			return DbContext.Set<UnitCategory>().AsNoTracking()
				.FirstOrDefaultAsync(ug => ug.Category.Id == categoryId && ug.Unit.Id == unitId);
		}

		public Task<UnitCategory> GetbyBattleScribeIds(string categoryId, string unitId)
		{
			return DbContext.Set<UnitCategory>().AsNoTracking().FirstOrDefaultAsync(ug =>
				ug.Category.BattleScribeId == categoryId && ug.Unit.BattleScribeId == unitId);
		}
	}

	public class KeywordRepository : GenericRepository<Keyword>, IKeywordRepository
	{
		public KeywordRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}

	public class UnitKeywordRepository : GenericRepository<UnitKeyword>, IUnitKeywordRepository
	{
		public UnitKeywordRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public Task<UnitKeyword> GetbyIds(int keywordId, int unitId)
		{
			return DbContext.Set<UnitKeyword>().AsNoTracking()
				.FirstOrDefaultAsync(ug => ug.Keyword.Id == keywordId && ug.Unit.Id == unitId);
		}

		public Task<UnitKeyword> GetbyBattleScribeIds(string keywordId, string unitId)
		{
			return DbContext.Set<UnitKeyword>().AsNoTracking().FirstOrDefaultAsync(ug =>
				ug.Keyword.BattleScribeId == keywordId && ug.Unit.BattleScribeId == unitId);
		}
	}
}