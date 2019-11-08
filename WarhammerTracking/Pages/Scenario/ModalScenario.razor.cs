using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.Scenario
{
	public class ModalScenarioPage : BasePage
	{
		[CascadingParameter]
		public ModalParameters Parameters { get; set; }
		protected Data.Models.Scenario Scenario { get; set; }
		
		protected override async Task OnInitializedAsync()
		{
			var scenarioId = Parameters.Get<string>("ScenarioId");
			Scenario = await ScenarioRepository.GetById(int.Parse(scenarioId));
		}

		protected void Cancel()
		{
			Modal.Cancel();
		}
	}
}