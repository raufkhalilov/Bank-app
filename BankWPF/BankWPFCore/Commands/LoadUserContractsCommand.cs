using BankWPFCore.Exceptions;
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
    internal class LoadUserContractsCommand : BaseAsyncCommand
    {
        private readonly ClientBlankViewModel _clientCardViewModel;
        //private readonly IContractsProvider _contractsProvider; //-
        private readonly Bank _bank;
        private readonly bool _isContactsLoading;

        public LoadUserContractsCommand(ClientBlankViewModel clientsViewModel, Bank bank, IContractsProvider contractsProvider, bool isContactsLoading = true)
        {
            _clientCardViewModel = clientsViewModel;
            //_contractsProvider = contractsProvider;
            _bank = bank;
            _isContactsLoading = isContactsLoading;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync()
        {



            if (_isContactsLoading)//флаг
            {
                _clientCardViewModel.IsLoading = true;

                try
                {
                    ObservableCollection<Contract> contracts = new ObservableCollection<Contract>(/*await _contractsProvider.GetAllContracts()*/await _bank.GetAllContracts());
                    _clientCardViewModel.ClientsActiveContracts = new ObservableCollection<Contract>(contracts.Where(c => c.ClientID == _clientCardViewModel.ClientID));
                }

                catch (ApiConnectionException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Ошибка подключения к серверу\n",
                        "Ошибка",
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Error);
                }

                _clientCardViewModel.IsLoading = false;
            }


        }
    }
}
