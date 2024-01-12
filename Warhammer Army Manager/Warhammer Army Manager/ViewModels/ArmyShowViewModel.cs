using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.Database.Models;
using System.Collections.ObjectModel;

namespace Warhammer_Army_Manager.ViewModels
{
    class ArmyShowViewModel : ViewModel
    {
        private Army _army;
        public Army Army
        {
            get => _army;
            set
            {
                _army = value;
                OnPropertyChanged();
            }
        }

        public ArmyShowViewModel()
        {
            //
        }
    }
}
