using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.GameTable
{
	public class DetailGameTable : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.GameTable GameTable;

		protected override async Task OnInitializedAsync()
		{
			GameTable = await GameTableRepository.GetById(Id);
		}
	}
}