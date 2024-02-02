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
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyViewModel : ViewModel
    {
        public ObservableCollection<Army> Armys { get; set; } = new();
        public Army SelectedArmy { get; set; } = new();
        public RelayCommand DeleteArmyCommand { get; set; }
        public RelayCommand ShowArmyCommand { get; set; }

        private IWindowService _window;
        public IWindowService WindowService
        {
            get => _window;
            set
            {
                _window = value;
                OnPropertyChanged();
            }
        }

        public ArmyViewModel(IWindowService window, DashboardViewModel DashboardVM, ArmyShowViewModel ArmyShowVM, ArmyShowView ArmyShowView)
        {
            WindowService = window;

            using (var context = new ApplicationDbContext())
            {
                foreach (Army t in context.Army.Include(x => x.Units).ToList())
                {
                    Armys.Add(t);
                }
            }

            DeleteArmyCommand = new RelayCommand(o =>
            {
                if (SelectedArmy is null)
                    return;
                if (MessageBox.Show($"Armee \"{SelectedArmy.Name}\" wirklich löschen?", "Zeile löschen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                    return;

                using var context = new ApplicationDbContext();
                context.Remove(context.Army.Single(a => a.Id == SelectedArmy.Id));
                context.SaveChanges();
                Armys.Remove(SelectedArmy);
                DashboardVM.ArmyCount = context.Army.Count();
            });

            ShowArmyCommand = new RelayCommand(o =>
            {
                ArmyShowVM.Army = SelectedArmy;
                WindowService.ShowWindow(ArmyShowView, (o as Window)!);
            });
        }
    }
}
