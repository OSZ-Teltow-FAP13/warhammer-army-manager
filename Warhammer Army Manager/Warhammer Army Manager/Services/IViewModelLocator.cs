using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager.Services
{
    interface IViewModelLocator
    {
        public ViewModel GetVM<TViewModel>() where TViewModel : ViewModel;
    }
}
