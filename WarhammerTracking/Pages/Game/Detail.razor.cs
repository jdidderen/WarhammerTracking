using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using WarhammerTracking.Pages.GameTable;
using WarhammerTracking.Pages.Scenario;

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
		
		protected void ShowGameTable()
		{
			var parameters = new ModalParameters();
			parameters.Add("GameTableId", Game.GameTable.Id.ToString());
			Modal.Show<ModalGameTable>("Game Table", parameters);
		}
		
		protected void ShowScenario()
		{
			var parameters = new ModalParameters();
			parameters.Add("ScenarioId", Game.Scenario.Id.ToString());
			Modal.Show<ModalScenario>("Scenario", parameters);
		}
	}
}