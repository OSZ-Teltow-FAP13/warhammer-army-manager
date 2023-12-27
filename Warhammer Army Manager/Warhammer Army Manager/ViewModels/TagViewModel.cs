using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.ViewModels.Commands;
using Warhammer_Army_Manager.Models;
using System.Windows.Input;
using System.Windows;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.ViewModels
{
    class TagViewModel : ViewModel
    {
        public ObservableCollection<Tag> Tags { get; set; }

        public RelayCommand ShowWindowCommand { get; set; }

        public TagViewModel(TagAddView view)
        {
            Tags = TagManager.GetTags();

            ShowWindowCommand = new RelayCommand(o =>
            {
                var mainWindow = o as Window;
                view.Owner = mainWindow;
                view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                view.Show();
            });
        }

    }
}
