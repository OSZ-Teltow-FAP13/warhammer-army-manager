using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.Database
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
        {
            /*
            MySQL Setup -- save for later
            var connectionString = "server=localhost;user=root;password=;database=ef";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            optionsBuilder
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            */

            optionsBuilder.UseSqlite("Data Source = WAMData.db");
        }

        public DbSet<Army> Army { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Wounds);
                entity.Property(e => e.Bravery);
                entity.Property(e => e.Save);
                entity.Property(e => e.Points);
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Name);
                entity.Property(e => e.Range);
                entity.Property(e => e.Attacks);
                entity.Property(e => e.ToHit);
                entity.Property(e => e.ToWound);
                entity.Property(e => e.Rend);
                entity.Property(e => e.Damage);
                entity.Property(e => e.SpecialEffect);
            });

            modelBuilder.Entity<Army>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Points);
            });
        }
    }
}
