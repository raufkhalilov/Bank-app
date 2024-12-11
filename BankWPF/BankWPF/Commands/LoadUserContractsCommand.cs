using BankWPF.Models;
using BankWPF.Services;
using BankWPF.Services.ApiServices;
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
    internal class LoadUserContractsCommand : BaseAsyncCommand
    {
        private readonly ClientBlankViewModel _clientCardViewModel;
        private readonly IContractsProvider _contractsProvider;

        public LoadUserContractsCommand(ClientBlankViewModel clientsViewModel, IContractsProvider contractsProvider)
        {
            _clientCardViewModel = clientsViewModel;
            _contractsProvider = contractsProvider;
        }

        public override async Task ExecuteAsync()
        {
            try
            {
                ObservableCollection<Contract> contracts = new ObservableCollection<Contract>(await _contractsProvider.GetAllContracts());
                _clientCardViewModel.ClientsActiveContracts = new ObservableCollection<Contract>(contracts.Where(c => c.ClientID == _clientCardViewModel.ClientID));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Ошибка подключения к серверу\n",
                    "Ошибка",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Error);
            }
        }
    }
}
