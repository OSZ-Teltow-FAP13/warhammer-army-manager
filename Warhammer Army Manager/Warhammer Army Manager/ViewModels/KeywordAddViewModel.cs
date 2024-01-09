using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.ViewModels.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    class KeywordAddViewModel : ViewModel
    {
        public RelayCommand AddViewCommand { get; set; }

        public string? Name { get; set; }

        public KeywordAddViewModel(DashboardViewModel vm)
        {
            AddViewCommand = new RelayCommand(o =>
            {
                KeywordManager.AddKeywords(new()
                {
                    Name = Name
                });

                vm.TagCount += 1;
            });

        }
    }
}
