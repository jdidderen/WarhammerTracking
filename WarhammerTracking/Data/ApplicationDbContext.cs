using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WarhammerTracking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Army.Army> Armies { get; set; }
        public virtual DbSet<Army.Faction> Factions { get; set; }
        public virtual DbSet<Game.Game> Games { get; set; }
        public virtual DbSet<GameRequest.GameRequest> GameRequests { get; set; }
        public virtual DbSet<Game.GameLine> GameLines { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game.Game>()
                .Property(b => b.Date)
                .HasDefaultValueSql("NOW()");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game.Game>()
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
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
