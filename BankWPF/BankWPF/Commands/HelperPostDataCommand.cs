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
    internal class HelperPostDataCommand : BaseAsyncCommand
    {

        private BankStore _bankStore;
        private NavigationViewModel _navigationViewModel;
       

        public HelperPostDataCommand(BankStore bankStore, NavigationViewModel navigationViewModel)
        {
            _bankStore = bankStore;
           _navigationViewModel = navigationViewModel;
        }

        public override async Task ExecuteAsync()
        {
           
            _bankStore.ReLoadBank();
            _navigationViewModel.NavigateClientsViewCommand.Execute(_bankStore);
        }
    }
}
