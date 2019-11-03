using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.User
{
	public class DeleteUser : BasePage
	{
		[Parameter]
		public string Id { get; set; }

		protected ApplicationUser ApplicationUser;

		protected override async Task OnInitializedAsync()
		{
			ApplicationUser = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("user");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await UserManager.DeleteAsync(ApplicationUser);
			NavigationManager.NavigateTo("user");
		}
	}
}