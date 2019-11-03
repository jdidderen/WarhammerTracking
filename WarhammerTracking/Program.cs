using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WarhammerTracking
{
	public class Program
	{
		public static void Main(string[] args)
		{
//            CreateHostBuilder(args).Build().Run();
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
		}

		private static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseKestrel(opts =>
				{
					opts.ListenLocalhost(5001, listenOptions => { listenOptions.UseHttps("warhammer.pfx", ""); });
				})
				.UseStartup<Startup>();
		}
	}
}