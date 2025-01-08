using BankWPFCore.Exceptions;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPFCore.Commands
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

            try
            {

                await _bankStore.LoadClients();
                _clientViewModel.UpdateClientsList(_bankStore.Clients);
            }
            catch (ApiConnectionException ex)
            {
                MessageBox.Show(ex.Comment + "\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            _clientViewModel.IsLoading = false;

            //TODO: add this code into try-catch block

        }
    }
}
