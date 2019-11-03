using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.GameRequest
{
	public class CreateGameRequest : BasePage
	{
		protected Data.Models.GameRequest GameRequest = new Data.Models.GameRequest();

		protected override async Task OnInitializedAsync()
		{
			GameRequest.Date = DateTime.Now;
			var user = await Task.FromResult(UserManager.Users.FirstOrDefault(u => u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name));
			GameRequest.Player = user;
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("gamerequest");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await GameRequestRepository.Create(GameRequest);
			NavigationManager.NavigateTo("gamerequest");
		}
	}
}