using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Services;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyAvailableUnitsViewModel : ViewModel
    {
        public ObservableCollection<Unit> Units { get; set; } = new();
        public Unit SelectedUnit { get; set; } = new();

        public ICommand AddCommand { get; set; }

        public ArmyAvailableUnitsViewModel(IViewModelLocator Locator)
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Unit u in context.Units.Include(x => x.Keywords).ToList())
                {
                    Units.Add(u);
                }
            }

            AddCommand = new RelayCommand(o =>
            {
                if (SelectedUnit is null)
                    return;

                ArmyAddViewModel aavm = Locator.GetVM<ArmyAddViewModel>() as ArmyAddViewModel;
                aavm.UnitsSelected.Add(SelectedUnit);


                aavm.updatePoints();
            });
        }

    }
}
