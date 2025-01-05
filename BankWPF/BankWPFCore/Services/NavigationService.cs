using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System;

namespace BankWPFCore.Services
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

        ~NavigationService(){
            base.ToString();
           //...
        }
    }
}
