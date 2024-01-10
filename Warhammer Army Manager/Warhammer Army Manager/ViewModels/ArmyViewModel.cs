using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyViewModel : ViewModel
    {
        public ObservableCollection<Army> Armys { get; set; }

        public ArmyViewModel()
        {
            Armys = new ObservableCollection<Army>();
            using (var context = new ApplicationDbContext())
            {
                foreach (Army t in context.Armys.ToList())
                {
                    Armys.Add(t);
                }
            }
        }
    }
}
