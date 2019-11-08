using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.GameTable
{
	public class ModalGameTablePage : BasePage
	{
		[CascadingParameter]
		public ModalParameters Parameters { get; set; }
		protected Data.Models.GameTable GameTable { get; set; }
		
		protected override async Task OnInitializedAsync()
		{
			var gameTableId = Parameters.Get<string>("GameTableId");
			GameTable = await GameTableRepository.GetById(int.Parse(gameTableId));
		}

		protected void Cancel()
		{
			Modal.Cancel();
		}
	}
}