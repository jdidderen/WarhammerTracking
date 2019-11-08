using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace WarhammerTracking.Pages.GameTable
{
	public class DeleteGameTable : BasePage
	{
		[Parameter] public int Id { get; set; }
		[Inject] protected IWebHostEnvironment _environment { get; set; }
		protected Data.Models.GameTable GameTable;

		protected override async Task OnInitializedAsync()
		{
			GameTable = await GameTableRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("gametable");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			if (!string.IsNullOrEmpty(GameTable.ImagePath))
			{
				var pathDelete = Path.Combine(_environment.WebRootPath,GameTable.ImagePath);
				File.Delete(pathDelete);
			}
			await GameTableRepository.Delete(Id);
			NavigationManager.NavigateTo("gametable");
		}
	}
}