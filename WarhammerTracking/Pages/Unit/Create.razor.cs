using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Unit
{
	public class CreateUnit : BasePage
	{
		protected readonly Data.Models.Unit Unit = new Data.Models.Unit();

		protected void Cancel()
		{
			NavigationManager.NavigateTo("unit");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await UnitRepository.Create(Unit);
			NavigationManager.NavigateTo("unit");
		}
	}
}