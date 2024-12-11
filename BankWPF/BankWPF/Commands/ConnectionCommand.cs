using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Commands
{
    internal class ConnectionCommand : BaseAsyncCommand
    {

        private BankStore _bankStore;
        private NavigationViewModel _navigationViewModel;
        private NavigationStore _navigationStore;
       

        public ConnectionCommand(BankStore bankStore, NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            _bankStore = bankStore;
           _navigationViewModel = navigationViewModel;
            _navigationStore = navigationStore;
        }

        public override async Task ExecuteAsync()
        {
           
            _bankStore.ReLoadBank();


            if (_navigationStore.CurrentViewModel.GetType() == typeof(ClientsListingViewModel))
            {
                _navigationViewModel.NavigateClientsViewCommand.Execute(_bankStore);
            }
            else if (_navigationStore.CurrentViewModel.GetType() == typeof(ContractsListingViewModel))
            {
                _navigationViewModel.NavigateContractsViewCommand.Execute(_bankStore);
            }
        }
    }
}
