using System.Linq;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.User
{
	public class ListUser : BasePage
	{
		protected IQueryable<ApplicationUser> ApplicationUsers;

		protected override async Task OnInitializedAsync()
		{
			ApplicationUsers = await Task.FromResult(UserManager.Users);
		}
	}
}