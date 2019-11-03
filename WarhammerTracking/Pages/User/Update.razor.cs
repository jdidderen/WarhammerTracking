using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.User
{
	public class UpdateUser : BasePage
	{
		[Parameter] public string Id { get; set; }
		[Required] protected string Role { get; set; }
		protected ApplicationUser ApplicationUser;

		protected override async Task OnInitializedAsync()
		{
			ApplicationUser = UserManager.Users.FirstOrDefault(ap => ap.Id == Id);
			ICollection<string> roles = await UserManager.GetRolesAsync(ApplicationUser);
			foreach (var rol in roles)
			{
				Role = rol;
			}
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("user");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			if (!string.IsNullOrEmpty(ApplicationUser.Password) &&
			    ApplicationUser.Password == ApplicationUser.ConfirmPassword)
			{
				ApplicationUser.PasswordHash =
					UserManager.PasswordHasher.HashPassword(ApplicationUser, ApplicationUser.Password);
			}

			await UserManager.UpdateAsync(ApplicationUser);
			await UserManager.AddToRoleAsync(ApplicationUser, Role);
			NavigationManager.NavigateTo("user");
		}
	}
}