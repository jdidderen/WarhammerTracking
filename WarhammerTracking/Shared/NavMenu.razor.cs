using Microsoft.AspNetCore.Components;
using WarhammerTracking.Resources;
using WarhammerTracking.Services;

namespace WarhammerTracking.Shared
{
	public class NavMenuPage : ComponentBase
	{
		[Inject] protected LocalizationService L { get; set; }
		protected bool CollapseNavMenu = true;
		protected bool CollapseArmyMenu = true;
		protected bool CollapseGameMenu = true;
		protected bool CollapseAdminMenu = true;
		protected string ArmyMenuIcon = "oi oi-plus";
		protected string GameMenuIcon = "oi oi-plus";
		protected string AdminMenuIcon = "oi oi-plus";
		protected string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

		protected void ToggleNavMenu()
		{
			CollapseNavMenu = !CollapseNavMenu;
		}
		
                     
		protected void ToggleArmyMenu()
		{
			CollapseArmyMenu = !CollapseArmyMenu;
			ArmyMenuIcon = CollapseArmyMenu ? "oi oi-plus" : "oi oi-minus";
		}
		
		protected void ToggleGameMenu()
		{
			CollapseGameMenu = !CollapseGameMenu;
			GameMenuIcon = CollapseGameMenu ? "oi oi-plus" : "oi oi-minus";
		}
		
		protected void ToggleAdminMenu()
		{
			CollapseAdminMenu = !CollapseAdminMenu;
			AdminMenuIcon = CollapseAdminMenu ? "oi oi-plus" : "oi oi-minus";
		}
	}
}