using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.GameRequest
{
	public class DetailGameRequest : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.GameRequest GameRequest;

		protected override async Task OnInitializedAsync()
		{
			GameRequest = await GameRequestRepository.GetById(Id);
		}

		protected async void CreateGame()
		{
			var currentUser = UserManager.Users.FirstOrDefault(u => u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name);
			GameRequest.Expired = true;
			await GameRequestRepository.Update(GameRequest);
			if (currentUser != null)
				NavigationManager.NavigateTo("game/add/" + GameRequest.Player.Id + "/" + currentUser.Id + "/" +
				                             GameRequest.Date.ToString("dd-MM-yyyy"));
		}
	}
}