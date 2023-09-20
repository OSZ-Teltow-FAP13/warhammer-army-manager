using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.Models;

namespace Warhammer_Army_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using (var context = new UnitDbContext())
            {
                context.Database.EnsureCreated();

                var unit = new Unit
                {
                    Name = "Test"
                };
                context.Units.Add(unit);

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new UnitDbContext())
            {
                var units = context.Units.Include(p => p.Tag);
                foreach (var unit in units)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {unit.Id}");
                    data.AppendLine($"Name: {unit.Name}");
                    data.AppendLine($"Tag: {unit.Tag}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
