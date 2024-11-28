using BankWPF.Stores;
using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Services
{
    internal class NavigationService<TViewModel>
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createVM;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createVM)
        {
            _navigationStore = navigationStore;
            _createVM = createVM;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createVM();
        }
    }
}
