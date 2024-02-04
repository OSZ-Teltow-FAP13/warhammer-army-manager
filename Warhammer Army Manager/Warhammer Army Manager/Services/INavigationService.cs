using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager.Services
{
    interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;

        public void registerAdditionalWindows<TViewModel, TView>()
            where TViewModel : ViewModel
            where TView : Window;
    }
}
