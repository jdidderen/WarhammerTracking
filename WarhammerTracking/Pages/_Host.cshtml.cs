using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarhammerTracking.Pages
{
	public class _Host : PageModel
	{
		public void OnGet()
		{
			HttpContext.Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(
					new RequestCulture(
						CultureInfo.CurrentCulture,
						CultureInfo.CurrentUICulture)));
		}
	}
}