using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Objective
{
	public class CreateObjective : BasePage
	{
		protected readonly Data.Models.Objective Objective = new Data.Models.Objective();

		protected override async Task OnInitializedAsync()
		{
			Objective.Date = DateTime.Now;
			var user = await Task.FromResult(UserManager.Users.FirstOrDefault(u =>
				u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name));
			Objective.Player = user;
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("objective");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ObjectiveRepository.Create(Objective);
			NavigationManager.NavigateTo("objective");
		}
	}
}