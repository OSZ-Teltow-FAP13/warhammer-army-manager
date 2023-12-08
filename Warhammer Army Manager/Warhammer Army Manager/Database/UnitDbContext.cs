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
            });

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.HasKey(e=> e.Id);
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
        }
    }
}
