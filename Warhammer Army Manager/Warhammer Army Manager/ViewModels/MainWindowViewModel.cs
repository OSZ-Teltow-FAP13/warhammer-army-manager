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
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Views;
using System.Reflection;
using System.Windows;

namespace Warhammer_Army_Manager.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public string Version { get; set; }
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand ArmyViewCommand { get; set; }
        public RelayCommand ArmyAddViewCommand { get; set; }
        public RelayCommand UnitViewCommand { get; set; }
        public RelayCommand WeaponViewCommand { get; set; }
        public RelayCommand TagViewCommand { get; set; }

        public INavigationService Navigation { get; set; }

        public MainWindowViewModel(INavigationService nav)
        {
            Version = $"Version: {Assembly.GetExecutingAssembly().GetName().Version!.ToString()}";

            Navigation = nav;
            Navigation.NavigateTo<DashboardViewModel>();

            DashboardViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<DashboardViewModel>();
            });

            ArmyViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<ArmyViewModel>();
            });

            ArmyAddViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<ArmyAddViewModel>();
            });

            UnitViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<UnitViewModel>();
            });

            WeaponViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<WeaponViewModel>();
            });

            TagViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<KeywordViewModel>();
            });
        }

    }
}
