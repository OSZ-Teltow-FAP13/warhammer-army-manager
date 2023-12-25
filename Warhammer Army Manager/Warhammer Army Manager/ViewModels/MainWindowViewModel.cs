using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Models;
using Warhammer_Army_Manager.ViewModels.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand ArmyViewCommand { get; set; }
        public RelayCommand UnitViewCommand { get; set; }
        public RelayCommand WeaponViewCommand { get; set; }
        public RelayCommand TagViewCommand { get; set; }


        public DashboardViewModel DashboardVM { get; set; }
        public ArmyViewModel ArmyVM { get; set; }
        public UnitViewModel UnitVM { get; set; }
        public WeaponViewModel WeaponVM { get; set; }
        public TagViewModel TagVM { get; set; }

        private object _currentView = new DashboardViewModel();

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        
        public MainWindowViewModel()
        {
            DashboardVM = new DashboardViewModel();
            ArmyVM = new ArmyViewModel();
            UnitVM = new UnitViewModel();
            WeaponVM = new WeaponViewModel();
            TagVM = new TagViewModel();

            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
            });

            ArmyViewCommand = new RelayCommand(o =>
            {
                CurrentView = ArmyVM;
            });

            UnitViewCommand = new RelayCommand(o =>
            {
                CurrentView = UnitVM;
            });

            WeaponViewCommand = new RelayCommand(o =>
            {
                CurrentView = WeaponVM;
            });
        }

    }
}
