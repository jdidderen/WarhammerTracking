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

namespace WarhammerTracking.Pages.Game
{
	public class UpdateGame : BasePage
	{
		[Parameter] public int Id { get; set; }

		protected List<ApplicationUser> Users;
		protected Data.Models.Army[] Armies;
		protected string User1Id;
		protected string User2Id; 
		protected string ArmyPlayer1Id;
		protected string ArmyPlayer2Id;
		protected Data.Models.Game Game;
		protected bool ShowNote = true;
		protected bool ShowList1;
		protected bool ShowList2;

		protected override async Task OnInitializedAsync()
		{
			Users = await UserManager.Users.ToListAsync();
			Armies = await ArmyRepository.GetList();
			Game = await GameRepository.GetById(Id);
			Console.WriteLine(Game.Id);
			User1Id = Game.Player1.Id;
			User2Id = Game.Player2.Id;
			ArmyPlayer1Id = Game.ArmyPlayer1.Id.ToString();
			ArmyPlayer2Id = Game.ArmyPlayer2.Id.ToString();
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
	}
}