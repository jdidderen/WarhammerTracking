using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Army
{
	public class DeleteArmy : BasePage
	{
		protected Data.Models.Army Army;
		[Parameter]
		public int Id { get; set; }
		
		protected override async Task OnInitializedAsync()
		{
			Army = await ArmyRepository.GetById(Id);
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await ArmyRepository.Delete(Id);
			NavigationManager.NavigateTo("army");
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("army");
		}
	}
}