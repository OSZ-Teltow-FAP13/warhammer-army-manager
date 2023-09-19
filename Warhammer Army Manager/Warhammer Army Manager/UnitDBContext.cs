using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Models;

namespace Warhammer_Army_Manager
{
    internal class UnitDBContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
