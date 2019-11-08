using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using WarhammerTracking.Components;
using WarhammerTracking.Data.Models;
using WarhammerTracking.Pages.GameTable;
using WarhammerTracking.Pages.Scenario;

namespace WarhammerTracking.Pages.Game
{
	public class UpdateGame : BasePage
	{
		[Parameter] public int Id { get; set; }

		protected List<ApplicationUser> Users;
		protected Data.Models.Army[] Armies;
		protected Data.Models.GameTable[] GameTables;
		protected Data.Models.Scenario[] Scenarios;
		protected string User1Id;
		protected string User2Id; 
		protected string ArmyPlayer1Id;
		protected string ArmyPlayer2Id;
		protected string Scenario;
		protected string GameTable;
		protected Data.Models.Game Game = new Data.Models.Game();
		protected bool ShowNote = true;
		protected bool ShowList1;
		protected bool ShowList2;

		protected override async Task OnInitializedAsync()
		{
			Users = await  Task.FromResult(UserManager.Users.ToList());
			Armies = await ArmyRepository.GetList();
			Game = await GameRepository.GetById(Id);
			GameTables = await GameTableRepository.GetList();
			Scenarios = await ScenarioRepository.GetList();
			if (Game.Player1 != null)
			{
				User1Id = Game.Player1.Id;
			}
			else
			{
				User1Id = string.Empty;;
			}
			if (Game.Player2 != null)
			{
				User2Id = Game.Player2.Id;
			}
			else
			{
				User2Id = string.Empty;;
			}
			if (Game.ArmyPlayer1 != null)
			{
				ArmyPlayer1Id = Game.ArmyPlayer1.Id.ToString();
			}
			else
			{
				ArmyPlayer1Id = string.Empty;;
			}
			if (Game.ArmyPlayer2 != null)
			{
				ArmyPlayer2Id = Game.ArmyPlayer2.Id.ToString();
			}
			else
			{
				ArmyPlayer2Id = string.Empty;;
			}
			if (Game.GameTable != null)
			{
				GameTable = Game.GameTable.Id.ToString();
			}
			else
			{
				GameTable = string.Empty;;
			}
			if (Game.Scenario != null)
			{
				Scenario = Game.Scenario.Id.ToString();
			}
			else
			{
				Scenario = string.Empty;;
			}
		}

		protected void AddLine(string userId)
		{
			Game.GameLines.Add(new GameLine
				{Player = UserManager.Users.FirstOrDefault(u => u.Id == userId), Game = Game});
		}

		protected void Cancel()
		{
			NavigationManager.NavigateTo("game");
		}

		protected async void FormSubmit(EditContext editContext)
		{
			var user1 = UserManager.Users.FirstOrDefault(u => u.Id == User1Id);
			var user2 = UserManager.Users.FirstOrDefault(u => u.Id == User2Id);
			var army1 = await ArmyRepository.GetById(int.Parse(ArmyPlayer1Id));
			var army2 = await ArmyRepository.GetById(int.Parse(ArmyPlayer2Id));
			if (user1 != null && user2 != null && army1 != null && army2 != null)
			{
				Game.Player1 = user1;
				Game.Player2 = user2;
				Game.ArmyPlayer1 = army1;
				Game.ArmyPlayer2 = army2;
			}

			if (editContext.Validate())
			{
				await GameRepository.Update(Game);
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

		protected void ShowDiceModal()
		{
			var parameters = new ModalParameters();
			Modal.Show<RollDice>("Roll the Dices", parameters);
		}
		
		protected void ShowGameTable()
		{
			var parameters = new ModalParameters();
			parameters.Add("GameTableId", GameTable);
			Modal.Show<ModalGameTable>("Game Table", parameters);
		}
		
		protected void ShowScenario()
		{
			var parameters = new ModalParameters();
			parameters.Add("ScenarioId", Scenario);
			Modal.Show<ModalScenario>("Scenario", parameters);
		}
	}
}