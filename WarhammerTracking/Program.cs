using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(opts => {
                    opts.ListenLocalhost(5001, listenOptions =>
                    {
                        listenOptions.UseHttps("warhammer.pfx", "");
                    });
                })
                .UseStartup<Startup>();
    }
}
