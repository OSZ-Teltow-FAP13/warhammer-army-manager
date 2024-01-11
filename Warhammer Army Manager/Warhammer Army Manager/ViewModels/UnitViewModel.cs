using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.ViewModels
{
    class UnitViewModel : ViewModel
    {
        public ObservableCollection<Unit> Units { get; set; } = new();

        public UnitViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Unit u in context.Units.Include(x => x.Keywords).ToList())
                {
                    Units.Add(u);
                }
            }
        }
    }
}
