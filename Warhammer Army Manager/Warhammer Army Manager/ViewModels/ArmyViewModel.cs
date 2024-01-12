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

        public ArmyViewModel(IWindowService window, ArmyShowViewModel ArmyShowVM, ArmyShowView ArmyShowView)
        {

            WindowService = window;

            using (var context = new ApplicationDbContext())
            {
                foreach (Army t in context.Army.Include(x => x.Units).ToList())
                {
                    Armys.Add(t);
                }
            }

            ShowArmyCommand = new RelayCommand(o =>
            {
                ArmyShowVM.Army = Armys.Last();
                WindowService.ShowWindow(ArmyShowView, o as Window);
            });
        }
    }
}
