using BankWPFCore.Models;
using BankWPFCore.Services.ApiServices.Providers;
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
        private readonly IClientsProvider _clientsProvider;

        private readonly Bank _bank;

        public LoadSelectedContractCommand(ContractBlankViewModel contractCardViewModel, Bank bank, IClientsProvider clientsProvider)
        {
            _contractCardViewModel = contractCardViewModel;
            //_requestsToApiService = requestsToApiService;
            _clientsProvider = clientsProvider;
            _bank = bank;
        }

        public override async Task ExecuteAsync()
        {
            try
            {
                ObservableCollection<Client> clients = new ObservableCollection<Client>(/*await _clientsProvider.GetAllClients()*/await _bank.GetAllClients());
                _contractCardViewModel.ClientName = clients.Where(d => d.ClientId == _contractCardViewModel.ClientID).Select(c => c.ClientName).FirstOrDefault();
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

