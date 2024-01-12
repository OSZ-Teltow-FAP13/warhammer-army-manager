using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager.Services
{
    class WindowService : IWindowService
    {
        public void ShowWindow(ViewModel vm)
        {
            var newWindow = new Window();
            newWindow.DataContext = vm;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.Show();
        }
    }
}
