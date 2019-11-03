using System.Threading.Tasks;

namespace WarhammerTracking.Pages.Army
{
	public class ListArmy : BasePage
	{
		protected Data.Models.Army[] Armies;
		protected static string[] FilterList => new[] {"Name"};

		protected override async Task OnInitializedAsync()
		{
			Armies = await ArmyRepository.GetList();
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("army");
		}
	}
}