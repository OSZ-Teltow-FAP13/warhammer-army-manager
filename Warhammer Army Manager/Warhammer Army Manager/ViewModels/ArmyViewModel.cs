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
using Warhammer_Army_Manager.Services;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyViewModel : ViewModel
    {
        public ObservableCollection<Army> Armys { get; set; } = new();
        public RelayCommand ShowArmyCommand { get; set; }

        private IWindowService _window;
        public IWindowService Window
        {
            get => _window;
            set
            {
                _window = value;
                OnPropertyChanged();
            }
        }

        public ArmyViewModel(IWindowService window, ArmyShowViewModel ArmyShowVM)
        {

            Window = window;

            using (var context = new ApplicationDbContext())
            {
                foreach (Army t in context.Army.ToList())
                {
                    Armys.Add(t);
                }
            }

            ShowArmyCommand = new RelayCommand(o =>
            {
                ArmyShowVM.Army = Armys.First();
                Window.ShowWindow(ArmyShowVM);
            });
        }
    }
}
