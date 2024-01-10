using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.ViewModels
{
    class UnitViewModel : ViewModel
    {
        public ObservableCollection<Unit> Units { get; set; }
    }
}
