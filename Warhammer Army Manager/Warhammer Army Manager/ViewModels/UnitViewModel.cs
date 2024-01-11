using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.ViewModels
{
    class UnitViewModel : ViewModel
    {
        public ObservableCollection<Unit> Units { get; set; }

        public RelayCommand ShowWindowCommand { get; set; }

        public UnitViewModel(UnitAddView view)
        {
            Units = UnitManager.GetUnits();

            ShowWindowCommand = new RelayCommand(o =>
            {
                var mainWindow = o as Window;
                view.Owner = mainWindow;
                view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                view.Show();
            });
        }


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
