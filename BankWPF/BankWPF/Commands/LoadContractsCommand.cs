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
    internal class LoadContractsCommand : BaseAsyncCommand
    {
        private readonly BankStore _bankStore;
        private readonly ContractsListingViewModel _contractsViewModel;

        public LoadContractsCommand(ContractsListingViewModel clientsViewModel, BankStore bankStore)
        {
            _bankStore = bankStore;
            _contractsViewModel = clientsViewModel;
        }

        public override async Task ExecuteAsync()
        {
            _contractsViewModel.IsLoading = true;
            await _bankStore.LoadContracts();
            _contractsViewModel.UpdateContractsList(_bankStore.Contracts);
            _contractsViewModel.IsLoading = false;
        }
    }
}
