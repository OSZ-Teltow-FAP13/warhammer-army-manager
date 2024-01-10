using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Database;
using System.Windows.Input;
using System.Windows;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.ViewModels
{
    class KeywordViewModel : ViewModel
    {
        public ObservableCollection<Keyword> Keywords { get; set; }

        public RelayCommand ShowWindowCommand { get; set; }

        public KeywordViewModel(KeywordAddView view)
        {
            Keywords = KeywordManager.GetKeywords();

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
