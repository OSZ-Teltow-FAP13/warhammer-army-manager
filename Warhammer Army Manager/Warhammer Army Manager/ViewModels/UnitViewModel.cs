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
        public ObservableCollection<Unit> Units { get; set; }

        public UnitViewModel()
        {
            Units = new ObservableCollection<Unit>();
            using (var context = new ApplicationDbContext())
            {
                foreach (Unit t in context.Units.ToList())
                {
                    Units.Add(t);
                }
            }
        }


    }
}
