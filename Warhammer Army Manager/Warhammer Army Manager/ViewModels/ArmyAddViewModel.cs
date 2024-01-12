using Microsoft.EntityFrameworkCore;
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
        public RelayCommand AddUnitCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public Unit SelectedUnit { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        protected int _total;
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

        protected int _max;
        private string _maxPoints;
        public string MaxPoints
        {
            get => _maxPoints;
            set
            {
                _maxPoints = value;
                OnPropertyChanged();
            }
        }


        public ArmyAddViewModel(DashboardViewModel dvm, ArmyViewModel avm)
        {
            PopulateUnitsList();
            ResetTotalPoints();

            _max = 2000;
            MaxPoints = $"Maximal: {_max}";

            AddUnitCommand = new RelayCommand(o =>
            {
                if (SelectedUnit is null)
                    return;

                if(SelectedUnit.Points+_total > _max)
                {
                    MessageBox.Show("Einheit konnte nicht hinzugefügt werden.\nDie maximale Armee Punktzahl wurde überschritten.", "Einheit hinzufügen fehlgeschlagen", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                UnitsSelected.Add(SelectedUnit);
                UnitsAvailable.Remove(SelectedUnit);
                int total = 0;

                foreach (Unit u in UnitsSelected)
                    total += u.Points;

                TotalPoints = $"Punkte: {total}";
                _total = total;
            });

            SaveCommand = new RelayCommand(o =>
            {
                if (UnitsSelected is null)
                    return;

                using var context = new ApplicationDbContext();
                var newArmy = new Army
                {
                    Name = Name ?? $"MyArmy",
                    Points = _total
                };

                foreach (Unit u in UnitsSelected)
                    newArmy.Units.Add(context.Units.Include(x => x.Keywords).Where(x => x.Id == u.Id).First());

                context.Army.Add(newArmy);
                context.SaveChanges();

                // show the model before clearing the lists
                MessageBox.Show("Armee erfolgreich Aufgestellt.\nSie steht dir nun für deine nächsten Gefechte zur verfügung.", "Armee aufgestellt", MessageBoxButton.OK, MessageBoxImage.Information);

                UnitsSelected.Clear();
                PopulateUnitsList();
                ResetTotalPoints();

                // bump dashboard army count
                dvm.ArmyCount++;

                avm.Armys.Add(newArmy);
                Name = "";
            });
        }

        protected void PopulateUnitsList()
        {
            UnitsAvailable.Clear();

            using var context = new ApplicationDbContext();

            foreach (Unit u in context.Units.Include(x => x.Keywords).ToList())
                UnitsAvailable.Add(u);
        }

        protected void ResetTotalPoints()
        {
            TotalPoints = "Punkte: 0";
        }
    }
}
