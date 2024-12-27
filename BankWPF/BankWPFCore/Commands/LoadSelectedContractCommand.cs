using BankWPF.Models;
using BankWPF.ViewModels;
using BankWPFCore.Services.ApiServices.Get;
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
    internal class LoadSelectedContractCommand : BaseAsyncCommand
    {
        private readonly ContractBlankViewModel _contractCardViewModel;
        //private readonly IRequestsToApiService _requestsToApiService;
        private readonly IClientsProvider _clientsProvider;

        public LoadSelectedContractCommand(ContractBlankViewModel contractCardViewModel, IClientsProvider clientsProvider)
        {
            _contractCardViewModel = contractCardViewModel;
            //_requestsToApiService = requestsToApiService;
            _clientsProvider = clientsProvider;
        }

        public override async Task ExecuteAsync()
        {
            try
            {
                ObservableCollection<Client> clients = new ObservableCollection<Client>(await _clientsProvider.GetAllClients());
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

