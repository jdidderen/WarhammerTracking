using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.Objective
{
	public class DetailObjective : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.Objective Objective;

		protected override async Task OnInitializedAsync()
		{
			Objective = await ObjectiveRepository.GetById(Id);
		}
	}
}