using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Pages.Unit
{
	public class DetailUnit : BasePage
	{
		[Parameter]
		public int Id { get; set; }

		protected Data.Models.Unit Unit;

		protected override async Task OnInitializedAsync()
		{
			Unit = await UnitRepository.GetById(Id);
		}
	}
}