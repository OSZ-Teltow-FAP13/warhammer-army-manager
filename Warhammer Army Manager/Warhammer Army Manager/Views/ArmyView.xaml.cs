using System;
using System.Collections.Generic;
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
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Database;
using System.Collections;

namespace Warhammer_Army_Manager.Views
{
    /// <summary>
    /// Interaktionslogik für ArmyView.xaml
    /// </summary>
    public partial class ArmyView : UserControl
    {
        public ArmyView()
        {
            InitializeComponent();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ArmyList.SelectedItem as Army is null)
                return;

            if (MessageBox.Show("Wirklich löschen?", "Zeile löschen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                return;

            using var context = new ApplicationDbContext();
            context.Remove(context.Armys.Single(a => a.Id == (ArmyList.SelectedItem as Army)!.Id));
            context.SaveChanges();
            ArmyList.ItemsSource = context.Armys.ToList();
        }
    }
}
