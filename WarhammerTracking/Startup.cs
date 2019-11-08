using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WarhammerTracking.Areas.Identity;
using WarhammerTracking.Data;
using WarhammerTracking.Data.Models;
using WarhammerTracking.Data.Repository;
using WarhammerTracking.Services;

namespace WarhammerTracking
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseLazyLoadingProxies().UseNpgsql(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddDataProtection()
				.SetApplicationName("warhammer tracking")
				.PersistKeysToFileSystem(new DirectoryInfo("/opt/warhammer/keys/"));
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<LocalizationService>();
			services
				.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>
				>();
			services.AddScoped<IArmyRepository, ArmyRepository>();
			services.AddScoped<IGameRepository, GameRepository>();
			services.AddScoped<IGameRequestRepository, GameRequestRepository>();
			services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
			services.AddScoped<IUnitRepository, UnitRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IUnitCategoryRepository, UnitCategoryRepository>();
			services.AddScoped<IKeywordRepository, KeywordRepository>();
			services.AddScoped<IUnitKeywordRepository, UnitKeywordRepository>();
			services.AddScoped<IScenarioRepository, ScenarioRepository>();
			services.AddScoped<IGameTableRepository, GameTableRepository>();
			services.AddBlazoredModal();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
			UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
		{
			UpdateDatabase(app);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			var supportedCultures = new[]
			{
				new CultureInfo("en"),
				new CultureInfo("fr")
			};
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("en"),
				// Formatting numbers, dates, etc.
				SupportedCultures = supportedCultures,
				// UI strings that we have localized.
				SupportedUICultures = supportedCultures
			});
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});

			CreateUserRoles(serviceProvider).Wait();
			UserDataInitializer.SeedData(userManager);
		}


		private static void UpdateDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices
				.GetRequiredService<IServiceScopeFactory>()
				.CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
			context.Database.Migrate();
		}

		private static async Task CreateUserRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var adminRoleCheck = await roleManager.RoleExistsAsync("Admin");
			if (!adminRoleCheck) await roleManager.CreateAsync(new IdentityRole("Admin"));
			var userRoleCheck = await roleManager.RoleExistsAsync("User");
			if (!userRoleCheck) await roleManager.CreateAsync(new IdentityRole("User"));
			var user = await userManager.FindByEmailAsync("didderen.jeremy@jdi.me");
			await userManager.AddToRoleAsync(user, "Admin");
		}
	}
}