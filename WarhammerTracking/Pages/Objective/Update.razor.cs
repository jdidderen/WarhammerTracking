using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Objective
{
	public class UpdateObjective : BasePage
	{
		[Parameter] public int Id { get; set; }

		protected Data.Models.Objective Objective;

		protected override async Task OnInitializedAsync()
		{
			Objective = await ObjectiveRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("objective");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ObjectiveRepository.Update(Objective);
			NavigationManager.NavigateTo("objective");
		}
	}
}