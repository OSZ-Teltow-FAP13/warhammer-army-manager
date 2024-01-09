using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warhammer_Army_Manager.Models;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager.Views
{
    /// <summary>
    /// Interaktionslogik für TagView.xaml
    /// </summary>
    public partial class TagView : UserControl
    {

        public TagView()
        {
            InitializeComponent();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (TagList.SelectedItem as Tag is null)
                return;

            if (MessageBox.Show("Wirklich löschen?", "Zeile löschen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                return;

            using var context = new ApplicationDbContext();
            context.Remove(context.Tags.Single(a => a.Id == (TagList.SelectedItem as Tag)!.Id));
            context.SaveChanges();
            TagList.ItemsSource = context.Tags.ToList();
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Wirklich alle Einträge löschen?", "Zeile löschen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                return;
            
            // ToDo
        }
    }
}
