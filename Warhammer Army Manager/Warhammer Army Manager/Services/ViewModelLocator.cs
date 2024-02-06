using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.ViewModels;

namespace Warhammer_Army_Manager.Services
{
    class ViewModelLocator : IViewModelLocator
    {
        private readonly IServiceProvider _provider;

        public ViewModelLocator(IServiceProvider provider, Func<Type, ViewModel> viewModelFactory)
        {
            _provider = provider;
        }

        public ViewModel GetVM<TViewModel>() where TViewModel : ViewModel
        {
            return _provider.GetRequiredService<TViewModel>();
        }
    }
}
