using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WarhammerTracking.Pages.Game
{
	public class DeleteGame : BasePage
	{
		[Parameter] 
		public int Id { get; set; }

		protected Data.Models.Game Game;
		protected bool ShowNote = true;
		protected bool ShowList1;
		protected bool ShowList2;

		protected override async Task OnInitializedAsync()
		{
			Game = await GameRepository.GetById(Id);
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("game");
		}
		
		protected async void FormSubmit(EditContext editContext)
		{
			if (editContext.Validate())
			{
				await GameRepository.Delete(Id);
				NavigationManager.NavigateTo("game");
			}
			else
			{
				Console.WriteLine("Fail");
			}
		}

		protected void ChangeNoteView()
		{
			ShowNote = true;
			ShowList1 = false;
			ShowList2 = false;
		}

		protected void ChangeList1View()
		{
			ShowNote = false;
			ShowList1 = true;
			ShowList2 = false;
		}

		protected void ChangeList2View()
		{
			ShowNote = false;
			ShowList1 = false;
			ShowList2 = true;
		}
	}
}