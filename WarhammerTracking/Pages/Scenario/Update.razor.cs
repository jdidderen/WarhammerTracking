using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Scenario
{
	public class UpdateScenario : BasePage
	{
		[Parameter] public int Id { get; set; }

		protected Data.Models.Scenario Scenario;

		protected override async Task OnInitializedAsync()
		{
			Scenario = await ScenarioRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("scenario");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ScenarioRepository.Update(Scenario);
			NavigationManager.NavigateTo("scenario");
		}
	}
}