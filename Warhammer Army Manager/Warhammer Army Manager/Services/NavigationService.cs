using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.ViewModels;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.Services
{
    class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel _currentView;

        protected Dictionary<ViewModel, Window> VMAdditionalWindow { get; set; } = new();

        private readonly IServiceProvider _provider;
        private readonly IWindowService _windows;

        public ViewModel CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory, IServiceProvider provider, IWindowService windows)
        {
            _viewModelFactory = viewModelFactory;
            _provider = provider;
            _windows = windows;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
            handleAdditionalWindows();
        }

        private void handleAdditionalWindows()
        {
            foreach (var item in VMAdditionalWindow)
            {
                // close all windows that are not assosiated with the current VM
                if (!CurrentView.Equals(item.Key)) // && Helpers.IsWindowOpen<type>()
                {
                    item.Value.Visibility = Visibility.Hidden;
                    return;
                }

                _windows.ShowWindow(item.Value, _provider.GetRequiredService<MainWindow>());
            }
        }

        public void registerAdditionalWindows<TViewModel, TView>()
            where TViewModel : ViewModel
            where TView : Window
        {
            VMAdditionalWindow.Add(_provider.GetRequiredService<TViewModel>(), _provider.GetRequiredService<TView>());
        }
    }
}
