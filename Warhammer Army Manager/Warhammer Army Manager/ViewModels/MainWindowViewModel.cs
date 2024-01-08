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
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.ViewModels.Commands;

namespace Warhammer_Army_Manager.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string? _Name;
        private IList<Unit> _Units;
        private readonly DelegateCommand _changeNameCommand;

        public ICommand ChangeNameCommand => _changeNameCommand;

        public string Name
        {
            get => _Name;
            set => base.SetProperty(ref _Name, value);
        }
        public IList<Unit> Units
        {
            get => _Units;
            set => base.SetProperty(ref _Units, value);
        }

        public MainWindowViewModel()
        {
            _Units = new List<Unit>
            {
                new Unit {}
            };

            _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
        }

        private void OnChangeName(object commandParameter)
        {
            Name = "Walter";
            _changeNameCommand.InvokeCanExecuteChanged();
        }

        private bool CanChangeName(object commandParameter)
        {
            return Name != "Walter";
        }

    }
}
