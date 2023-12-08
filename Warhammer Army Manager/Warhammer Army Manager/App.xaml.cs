using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Tables;

namespace Warhammer_Army_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {              
            addSampleData();
        }

        private static void addSampleData()
        {
            using (var context = new UnitDbContext())
            {
                context.Database.EnsureCreated();

                string unitName = "TestBlubberDUmpfbacke";
                if (!context.Units.Any(unit => unit.Name == unitName))
                {
                    var unitHorses = new Unit
                    {
                        Name = unitName,
                        Wounds = 10,
                        Move = 8,
                        Bravery = 9,
                        Save = "1+",
                    };
                    context.Units.Add(unitHorses);
                }

                context.SaveChanges();
            }
        }
    }
}
