using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Database;

namespace Warhammer_Army_Manager.ViewModels
{
    class DashboardViewModel : ViewModel
    {
        private int _armyCount;
        private int _unitCount;
        private int _weaponCount;
        private int _keywordCount;
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
        public int KeywordCount
        {
            get => _keywordCount;
            set
            {
                _keywordCount = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                ArmyCount = context.Army.Count();
                UnitCount = context.Units.Count();
                WeaponCount = context.Weapons.Count();
                KeywordCount = context.Keywords.Count();
            }
        }

    }
}
