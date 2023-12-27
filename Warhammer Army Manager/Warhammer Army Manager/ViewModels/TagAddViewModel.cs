using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Models;
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.ViewModels.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    class TagAddViewModel : ViewModel
    {
        public RelayCommand AddTagCommand { get; set; }

        public string? Name { get; set; }
        public string? Slug { get; set; }

        public TagAddViewModel(DashboardViewModel vm)
        {
            AddTagCommand = new RelayCommand(o =>
            {
                TagManager.AddTags(new()
                {
                    Name = Name,
                    Slug = Slug
                });

                vm.TagCount += 1;
            });

        }
    }
}
