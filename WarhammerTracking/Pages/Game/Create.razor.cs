using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.Game
{
	public class CreateGame : BasePage
	{
		[Parameter] 
		public string Player1 { get; set; }
		[Parameter] 
		public string Player2 { get; set; }
		[Parameter]
		public string Date { get; set; }

		protected List<ApplicationUser> Users;
		protected Data.Models.Army[] Armies;
		protected Data.Models.GameTable[] GameTables;
		protected Data.Models.Scenario[] Scenarios;
		protected string User1Id;
		protected string User2Id;
		protected string ArmyPlayer1;
		protected string ArmyPlayer2;
		protected string Scenario;
		protected string GameTable;
		protected readonly Data.Models.Game Game = new Data.Models.Game();
		protected bool ShowNote = true;
		protected bool ShowList1;
		protected bool ShowList2;
		
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine(CultureInfo.CurrentCulture);
			Users = UserManager.Users.ToList();
			Armies = await ArmyRepository.GetList();
			GameTables = await GameTableRepository.GetList();
			Scenarios = await ScenarioRepository.GetList();
			if (!string.IsNullOrEmpty(Player1) && !string.IsNullOrEmpty(Player2) && !string.IsNullOrEmpty(Date))
			{
				User1Id = Player1;
				User2Id = Player2;
				//            game.Date = DateTime.ParseExact(date, "dd-MM-yyyy",null);
			}
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("game");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			Console.WriteLine(User1Id);
			Console.WriteLine(User2Id);
			Console.WriteLine(ArmyPlayer1);
			Console.WriteLine(ArmyPlayer2);
			var user1 = UserManager.Users.FirstOrDefault(ap => ap.Id == User1Id);
			var user2 = UserManager.Users.FirstOrDefault(ap => ap.Id == User2Id);
			var army1 = await ArmyRepository.GetById(int.Parse(ArmyPlayer1));
			var army2 = await ArmyRepository.GetById(int.Parse(ArmyPlayer2));
			if (user1 != null && user2 != null && army1 != null && army2 != null)
			{
				Game.Player1 = user1;
				Game.Player2 = user2;
				Game.ArmyPlayer1 = army1;
				Game.ArmyPlayer2 = army2;
			}

			if (!editContext.Validate()) return;
			await GameRepository.Create(Game);
			if (Game.NoDetails)
			{
				NavigationManager.NavigateTo("game");
			}
			else
			{
				NavigationManager.NavigateTo("game/edit/" + Game.Id);
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