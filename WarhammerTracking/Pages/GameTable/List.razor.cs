using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.GameTable
{
	public class ListGameTable : BasePage
	{
		protected Data.Models.GameTable[] GameTables;

		protected override async Task OnInitializedAsync()
		{
			GameTables = await GameTableRepository.GetList();
		}
	}
}