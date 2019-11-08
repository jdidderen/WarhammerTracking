using System;
using System.IO;
using System.Linq;
using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace WarhammerTracking.Pages.GameTable
{
	public class CreateGameTable : BasePage
	{
		protected readonly Data.Models.GameTable GameTable = new Data.Models.GameTable();
		protected IFileListEntry Image;
		[Inject] protected IWebHostEnvironment _environment { get; set; }

		protected void Cancel()
		{
			NavigationManager.NavigateTo("gametable");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			if (!editContext.Validate()) return;
			if (Image != null)
			{
				if (Image.Type != "image/png" && Image.Type != "image/jpeg")
				{
					return;
				}
				var path = Path.Combine(_environment.WebRootPath, "Storage/GameTable/", Image.Name);
				await using var stream = new FileStream(path, FileMode.Create);
				await Image.Data.CopyToAsync(stream);
				GameTable.ImagePath = "Storage/GameTable/"+Image.Name;
			}
			await GameTableRepository.Create(GameTable);
			NavigationManager.NavigateTo("gametable");
		}
		
		protected void HandleFileSelected(IFileListEntry[] files)
		{
			Image = files.FirstOrDefault();
		}
	}
}