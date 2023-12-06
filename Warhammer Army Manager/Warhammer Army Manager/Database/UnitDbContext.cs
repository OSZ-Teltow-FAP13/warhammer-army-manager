using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Database.Tables;

namespace Warhammer_Army_Manager.Database
{
    internal class UnitDbContext : ApplicationDbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Keywords> Keywords { get; set; }
        public DbSet<Keywords> Weapons { get; set; }
        public DbSet<Keywords> UnitKeywords { get; set; }
        public DbSet<Keywords> UnitWeapons { get; set; }

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
                entity.HasMany(d => d.Tag);
            });

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.HasKey(e=> e.Id);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Range).IsRequired();
                entity.Property(e => e.Attacks).IsRequired();
                entity.Property(e => e.ToHit).IsRequired();
                entity.Property(e => e.ToWound).IsRequired();
                entity.Property(e => e.Rend);
                entity.Property(e => e.Damage).IsRequired();
                entity.Property(e => e.SpecialEffect);
            });

            modelBuilder.Entity<UnitKeywords>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitId).IsRequired();
                entity.Property(e => e.KeywordId).IsRequired();
            });

            modelBuilder.Entity<UnitWeapons>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitId).IsRequired();
                entity.Property(e => e.WeaponId).IsRequired();
            });
        }
    }
}
