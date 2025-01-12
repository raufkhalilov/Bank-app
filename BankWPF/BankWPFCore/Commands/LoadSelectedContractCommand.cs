using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Commands
{
    internal class LoadSelectedContractCommand : BaseAsyncCommand
    {
        private readonly ContractBlankViewModel _contractCardViewModel;
        //private readonly IRequestsToApiService _requestsToApiService;
        //private readonly IClientsProvider _clientsProvider;

        private readonly BankStore _bank;

        public LoadSelectedContractCommand(ContractBlankViewModel contractCardViewModel, BankStore bankStore)
        {
            _contractCardViewModel = contractCardViewModel;
            //_requestsToApiService = requestsToApiService;
            //_clientsProvider = clientsProvider;
            _bank = bankStore;
        }

        public override async Task ExecuteAsync()
        {
            try
            {
                if(_bank.Clients.Count == 0)
                    await _bank.LoadClients();

                ObservableCollection<Client> clients = new ObservableCollection<Client>(/*await _clientsProvider.GetAllClients()*/ _bank.Clients);
                _contractCardViewModel.Client = clients.Where(d => d.ClientId == _contractCardViewModel.Contract.ClientID).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ошибка подключения к серверу. ",
                    "Ошибка",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Error);
            }
        }
    }
}

