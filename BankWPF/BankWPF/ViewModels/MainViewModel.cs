using BankWPF.Services;
using BankWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        //public BaseViewModel CurrentViewModel { get;  }

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(/**/NavigationStore navigationStore)
        {

            // dialogService = new DialogService();
            //CurrentViewModel = new StartViewModel(dialogService);
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += CurrentViewModelChanged;

        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
