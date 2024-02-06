using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.ViewModels;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.Services
{
    class WindowService : IWindowService
    {
        public void ShowWindow(Window view, Window p)
        {
            // make sure window closes when parent gets closed
            view.Owner = p;

            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            view.Show();
        }
    }
}
