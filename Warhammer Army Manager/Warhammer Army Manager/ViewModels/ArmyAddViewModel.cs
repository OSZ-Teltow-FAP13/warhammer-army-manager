using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyAddViewModel : ViewModel
    {
        public ObservableCollection<Unit> UnitsSelected { get; set; } = new();
        public ObservableCollection<Unit> UnitsAvailable { get; set; } = new();
        public RelayCommand AddCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public Unit SelectedUnit { get; set; }

        private string _totalPoints;
        public string TotalPoints
        {
            get => _totalPoints;
            set
            {
                _totalPoints = value;
                OnPropertyChanged();
            }
        }
        

        public ArmyAddViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Unit u in context.Units.ToList())
                    UnitsAvailable.Add(u);
            }

            AddCommand = new RelayCommand(o =>
            {
                if (SelectedUnit is null)
                    return;

                UnitsSelected.Add(SelectedUnit);
                UnitsAvailable.Remove(SelectedUnit);
                int total = 0;

                foreach (Unit u in UnitsSelected)
                    total += u.Points;

                TotalPoints = $"Total: {total}";
            });

            SaveCommand = new RelayCommand(o =>
            {
                // ToDo: save army list
            });
        }
    }
}
