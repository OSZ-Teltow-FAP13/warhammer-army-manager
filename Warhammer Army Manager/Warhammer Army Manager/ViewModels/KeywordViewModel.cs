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
        public ObservableCollection<Keyword> Keywords { get; set; } = new();
        public Keyword SelectedKeyword { get; set; } = new();
        public RelayCommand DeleteCommand { get; set; }

        public KeywordViewModel()
        {
            Keywords = KeywordManager.GetKeywords();

            DeleteCommand = new RelayCommand(o =>
            {
                if (SelectedKeyword is null)
                    return;

                if (MessageBox.Show($"Schlüsselwort \"{SelectedKeyword.Name}\" Wirklich löschen?", "Zeile löschen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                    return;

                using var context = new ApplicationDbContext();
                context.Remove(context.Keywords.Single(a => a.Id == SelectedKeyword.Id));
                context.SaveChanges();
                Keywords.Remove(SelectedKeyword);
            });
        }

    }
}
