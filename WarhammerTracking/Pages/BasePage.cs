using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WarhammerTracking.Data.Models;
using WarhammerTracking.Data.Repository;
using WarhammerTracking.Services;

namespace WarhammerTracking.Pages
{
	public class BasePage : ComponentBase
	{
		[Inject] protected IGameRepository GameRepository { get; set; }
		[Inject] protected IScenarioRepository ScenarioRepository { get; set; }
		[Inject] protected IGameTableRepository GameTableRepository { get; set; }
		[Inject] protected IArmyRepository ArmyRepository { get; set; }
		[Inject] protected IUnitRepository UnitRepository { get; set; }
		[Inject] protected IKeywordRepository KeywordRepository { get; set; }
		[Inject] protected ICategoryRepository CategoryRepository { get; set; }
		[Inject] protected IUnitCategoryRepository UnitCategoryRepository { get; set; }
		[Inject] protected IUnitKeywordRepository UnitKeywordRepository { get; set; }
		[Inject] protected IGameRequestRepository GameRequestRepository { get; set; }
		[Inject] protected IObjectiveRepository ObjectiveRepository { get; set; }
		[Inject] protected NavigationManager NavigationManager { get; set; }
		[Inject] protected UserManager<ApplicationUser> UserManager { get; set; }
		[Inject] protected IHttpContextAccessor HttpContextAccessor { get; set; }
		[Inject] protected LocalizationService L { get; set; }
		[Inject] protected IModalService Modal { get; set; }
	}
}