using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Models;

namespace Warhammer_Army_Manager.ViewModels
{
    class DashboardViewModel : ViewModel
    {
        private int _armyCount;
        private int _unitCount;
        private int _weaponCount;
        private int _tagCount;
        public int ArmyCount
        {
            get => _armyCount;
            set
            {
                _armyCount = value;
                OnPropertyChanged();
            }
        }
        public int UnitCount
        {
            get => _unitCount;
            set
            {
                _unitCount = value;
                OnPropertyChanged();
            }
        }
        public int WeaponCount
        {
            get => _weaponCount;
            set
            {
                _weaponCount = value;
                OnPropertyChanged();
            }
        }
        public int TagCount
        {
            get => _tagCount;
            set
            {
                _tagCount = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                ArmyCount = context.Tags.Count();
                UnitCount = context.Tags.Count();
                WeaponCount = context.Tags.Count();
                TagCount = context.Tags.Count();
            }
        }

    }
}
