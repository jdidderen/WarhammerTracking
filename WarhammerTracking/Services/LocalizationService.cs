using System.Reflection;
using Microsoft.Extensions.Localization;
using WarhammerTracking.Resources;

namespace WarhammerTracking.Services
{
	public class LocalizationService
	{
		private readonly IStringLocalizer _localizer;
 
		public LocalizationService(IStringLocalizerFactory factory)
		{
			var type = typeof(Localization);
			var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
			_localizer = factory.Create("Localization", assemblyName.Name);
		}
 
		public LocalizedString GetLocalization(string key)
		{
			return _localizer[key];
		}
	}
}