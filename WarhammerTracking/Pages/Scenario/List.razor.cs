using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.Scenario
{
	public class ListScenario : BasePage
	{
		protected Data.Models.Scenario[] Scenarios;

		protected override async Task OnInitializedAsync()
		{
			Scenarios = await ScenarioRepository.GetList();
		}
	}
}