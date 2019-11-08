using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace WarhammerTracking.Pages.GameTable
{
	public class UpdateGameTable : BasePage
	{
		[Parameter] public int Id { get; set; }
		protected IFileListEntry Image;
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
			if (Image != null)
			{
				if (!string.IsNullOrEmpty(GameTable.ImagePath))
				{
					var pathDelete = Path.Combine(_environment.WebRootPath,GameTable.ImagePath);
					File.Delete(pathDelete);
				}
				var path = Path.Combine(_environment.WebRootPath, "Storage/GameTable/", Image.Name);
				await using var stream = new FileStream(path, FileMode.Create);
				await Image.Data.CopyToAsync(stream);
				GameTable.ImagePath = "Storage/GameTable/"+Image.Name;
			}
			await GameTableRepository.Update(GameTable);
			NavigationManager.NavigateTo("gametable");
		}
		
		protected void HandleFileSelected(IFileListEntry[] files)
		{
			var img = files.FirstOrDefault();
			if (img != null && (img.Type == "image/png" || img.Type == "image/jpeg"))
			{
				Image = img;
			}
		}
	}
}