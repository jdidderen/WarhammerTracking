using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.Scenario
{
	public class DetailScenario : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.Scenario Scenario;

		protected override async Task OnInitializedAsync()
		{
			Scenario = await ScenarioRepository.GetById(Id);
		}
	}
}