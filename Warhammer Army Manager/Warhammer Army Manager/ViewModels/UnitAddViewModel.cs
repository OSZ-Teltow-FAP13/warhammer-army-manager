using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    class UnitAddViewModel : ViewModel
    {
        public RelayCommand AddViewCommand { get; set; }

        public string? Name { get; set; }

        public int Wounds { get; set; }

        public int Move { get; set; }

        public int Bravery { get; set; }

        public string? Save { get; set; }

        public int Points { get; set; }

        public UnitAddViewModel(DashboardViewModel vm)
        {
            AddViewCommand = new RelayCommand(o =>
            {
                UnitManager.AddUnits(new()
                {
                    Name = Name,
                    Wounds = Wounds,
                    Move = Move,
                    Bravery = Bravery,
                    Save = Save,
                    Points = Points

                });

                vm.UnitCount += 1;
            });

        }
    }
}
