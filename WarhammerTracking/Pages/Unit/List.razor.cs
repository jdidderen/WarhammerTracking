using System.Threading.Tasks;

namespace WarhammerTracking.Pages.Unit
{
	public class ListUnit : BasePage
	{
		protected Data.Models.Unit[] Units;
		protected static string[] FilterList => new[] {"Name"};
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			Units = await UnitRepository.GetList();
		}
	}
}