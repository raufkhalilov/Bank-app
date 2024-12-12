using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Stores;
using BankWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF.Commands
{
    internal class LoadClientsCommand : BaseAsyncCommand
    {
        private readonly ClientsListingViewModel _clientViewModel;
        //private readonly IRequestsToApiService _requestsToApiService;
        private BankStore _bankStore;

        public LoadClientsCommand(ClientsListingViewModel clientsViewModel, BankStore bankStore) 
        {
            _bankStore = bankStore;
            _clientViewModel = clientsViewModel;
        }

        public override async Task ExecuteAsync()
        {

           
            _clientViewModel.IsLoading = true;

                await _bankStore.LoadClients();
                _clientViewModel.UpdateClientsList(_bankStore.Clients);

            _clientViewModel.IsLoading = false;
      
        }
    }
}
