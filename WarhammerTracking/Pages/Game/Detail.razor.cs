using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.Game
{
	public class DetailGame : BasePage
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