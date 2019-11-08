using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public virtual DbSet<Army> Armies { get; set; }
		public virtual DbSet<Unit> Units { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<UnitCategory> UnitsCategories { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameRequest> GameRequests { get; set; }
		public virtual DbSet<GameLine> GameLines { get; set; }
		public virtual DbSet<GameTable> GameTables { get; set; }
		public virtual DbSet<Scenario> Scenarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<UnitCategory>()
				.HasOne(ug => ug.Category)
				.WithMany(c => c.Units);
			modelBuilder.Entity<UnitCategory>()
				.HasOne(ug => ug.Unit)
				.WithMany(u => u.Categories);
			modelBuilder.Entity<UnitKeyword>()
				.HasOne(uk => uk.Keyword)
				.WithMany(k => k.Units);
			modelBuilder.Entity<UnitKeyword>()
				.HasOne(uk => uk.Unit)
				.WithMany(u => u.Keywords);
			modelBuilder.Entity<Game>()
				.HasMany(g => g.GameLines)
				.WithOne(l => l.Game);
			modelBuilder.Entity<ApplicationUser>()
				.HasMany(u => u.Player1Games)
				.WithOne(g => g.Player1);
			modelBuilder.Entity<ApplicationUser>()
				.HasMany(u => u.Player2Games)
				.WithOne(g => g.Player2);
			modelBuilder.Entity<ApplicationUser>()
				.HasMany(u => u.GameLines)
				.WithOne(g => g.Player);
			modelBuilder.Entity<ApplicationUser>()
				.HasMany(u => u.GameRequests)
				.WithOne(gr => gr.Player);
			modelBuilder.Entity<ApplicationUser>()
				.HasMany(u => u.Objectives)
				.WithOne(gr => gr.Player);
		}
	}
}