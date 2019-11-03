using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Unit
{
	public class DeleteUnit : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.Unit Unit;

		protected override async Task OnInitializedAsync()
		{
			Unit = await UnitRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("unit");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			await UnitRepository.Delete(Id);
			NavigationManager.NavigateTo("unit");
		}
	}
}