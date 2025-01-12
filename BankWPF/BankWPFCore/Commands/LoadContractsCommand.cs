using BankWPFCore.Exceptions;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Commands
{
    internal class LoadContractsCommand : BaseAsyncCommand
    {
        private readonly BankStore _bankStore;
        private readonly ContractsListingViewModel _contractsViewModel;

        public LoadContractsCommand(ContractsListingViewModel contractsListingViewModel, BankStore bankStore)
        {
            _bankStore = bankStore;
            _contractsViewModel = contractsListingViewModel;
        }

        public override async Task ExecuteAsync()
        {
            _contractsViewModel.IsLoading = true;
            _contractsViewModel.ErrorMessage = string.Empty;

            try
            {
                await _bankStore.LoadContracts();
                _contractsViewModel.UpdateContractsList(_bankStore.Contracts);
            }
            catch (ApiConnectionException ex)
            {
                //MessageBox.Show(ex.Comment + "\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _contractsViewModel.ErrorMessage = "При загрузке договоров произошла ошибка!";
            }


            _contractsViewModel.IsLoading = false;
        }
    }
}
