using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        

        public ArmyAddViewModel(DashboardViewModel dvm)
        {
            PopulateUnitsList();
            ResetTotalPoints();

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
                if (UnitsSelected is null)
                    return;

                using var context = new ApplicationDbContext();
                var newArmy = new Army
                {
                    Name = $"MyArmy-{context.Army.Count()}",
                    Points = 1337
                };

                foreach (Unit u in UnitsSelected)
                    newArmy.Units.Add(context.Units.Where(x => x.Id == u.Id).First());

                context.Army.Add(newArmy);
                context.SaveChanges();

                // show the model before clearing the lists
                MessageBox.Show("Armee erfolgreich Aufgestellt.\nSie steht dir nun für deine nächsten Gefechte zur verfügung.", "Armee aufgestellt", MessageBoxButton.OK, MessageBoxImage.Information);

                UnitsSelected.Clear();
                PopulateUnitsList();
                ResetTotalPoints();

                // bump dashboard army count
                dvm.ArmyCount++;
            });
        }

        protected void PopulateUnitsList()
        {
            UnitsAvailable.Clear();

            using var context = new ApplicationDbContext();

            foreach (Unit u in context.Units.ToList())
                UnitsAvailable.Add(u);
        }

        protected void ResetTotalPoints()
        {
            TotalPoints = "Total: 0";
        }
    }
}
