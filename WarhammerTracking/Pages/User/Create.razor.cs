using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.User
{
	public class CreateUser : BasePage
	{
		[Required] protected string Role { get; set; }

		protected readonly ApplicationUser ApplicationUser = new ApplicationUser();

		protected void Cancel()
		{
			NavigationManager.NavigateTo("user");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			ApplicationUser.PasswordHash =
				UserManager.PasswordHasher.HashPassword(ApplicationUser, ApplicationUser.Password);
			await UserManager.CreateAsync(ApplicationUser);
			await UserManager.AddToRoleAsync(ApplicationUser, Role);
			NavigationManager.NavigateTo("user");
		}
	}
}