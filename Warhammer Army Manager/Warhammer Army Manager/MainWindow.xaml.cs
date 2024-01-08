using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var MainWindowViewModel = new MainWindowViewModel();
            MainWindowViewModel.Name = "Kevin";

            DataContext = MainWindowViewModel;
            InitializeComponent();

            MainWindowViewModel.Name = "Mark";
        }

        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {
            using (UnitDbContext context = new UnitDbContext())
            {
                MessageBox.Show(context.Keywords.ToQueryString());
                Unit unit = context.Units.FirstOrDefault(unit => unit.Name == "187 Pferde der Beflügelung");
                if(unit != null)
                {
                    MessageBox.Show("Einheiten ID: " + unit.Id);
                }

            }
        }
    }
}
