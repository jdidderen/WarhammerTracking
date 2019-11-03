using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Army
{
	public class CreateArmy : BasePage
	{
		protected readonly Data.Models.Army Army = new Data.Models.Army();

		protected void Cancel()
		{
			NavigationManager.NavigateTo("army");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ArmyRepository.Create(Army);
			NavigationManager.NavigateTo("army");
		}
	}
}