using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warhammer_Army_Manager.Models;
using Warhammer_Army_Manager.ViewModels.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public DashboardViewModel DashboardVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            DashboardVM = new DashboardViewModel();
            CurrentView = DashboardVM;
        }

    }
}
