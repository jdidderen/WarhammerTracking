using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Scenario
{
	public class CreateScenario : BasePage
	{
		protected readonly Data.Models.Scenario Scenario = new Data.Models.Scenario();

		protected void Cancel()
		{
			NavigationManager.NavigateTo("scenario");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ScenarioRepository.Create(Scenario);
			NavigationManager.NavigateTo("scenario");
		}
	}
}