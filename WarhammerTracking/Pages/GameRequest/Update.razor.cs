using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.GameRequest
{
	public class UpdateGameRequest : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.GameRequest GameRequest;

		protected override async Task OnInitializedAsync()
		{
			GameRequest = await GameRequestRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("gamerequest");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await GameRequestRepository.Update(GameRequest);
			NavigationManager.NavigateTo("gamerequest");
		}
	}
}