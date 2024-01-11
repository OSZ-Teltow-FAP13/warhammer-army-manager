using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.Database
{
    class UnitManager
    {
        public static ObservableCollection<Unit> Units { get; set; } = new();

        public static ObservableCollection<Unit> GetUnits()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Unit t in context.Units.ToList())
                {
                    Units.Add(t);
                }
            }

            return Units;
        }
        public static void AddUnits(Unit units)
        {
            using (var context = new ApplicationDbContext())
            {
                Units.Add(units);
                
                context.Units.Add(units);
                context.SaveChanges();

            }
        }
    }
}
