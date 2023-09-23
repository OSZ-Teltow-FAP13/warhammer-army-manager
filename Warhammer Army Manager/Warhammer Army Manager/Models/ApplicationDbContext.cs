using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Models
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
    }
}
